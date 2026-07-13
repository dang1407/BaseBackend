using BaseBackend.Domain;
using Dapper;

namespace BaseBackend.Infrastructure
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(int bookingId);
        Task<List<Booking>> GetAllBookingsAsync();
        Task<List<Booking>> GetBookingsByRouteIdAsync(int car_tripId);
        Task<List<Booking>> GetBookingsByPhoneAsync(string phone);
        Task<List<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Booking> InsertBookingAsync(Booking booking);
        Task<int> UpdateBookingAsync(Booking booking);
        Task<int> DeleteBookingAsync(int bookingId);
        Task<int> UpdateBookingStatusAsync(int bookingId, int status);
    }

    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public async Task<Booking?> GetByIdAsync(int bookingId)
        {
            return await FindByIdAsync<Booking>(bookingId);
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            string query = @"
                SELECT * FROM booking 
                WHERE deleted = 0 
                ORDER BY created_time DESC";

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<Booking>(query);
            return result.ToList();
        }

        public async Task<List<Booking>> GetBookingsByRouteIdAsync(int car_tripId)
        {
            var param = new DynamicParameters();
            param.Add("@car_trip_id", car_tripId);

            string query = @"
                SELECT * FROM booking 
                WHERE deleted = 0 AND car_trip_id = @car_trip_id 
                ORDER BY departure_date DESC";

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<Booking>(query, param);
            return result.ToList();
        }

        public async Task<List<Booking>> GetBookingsByPhoneAsync(string phone)
        {
            var param = new DynamicParameters();
            param.Add("@phone", phone);

            string query = @"
                SELECT * FROM booking 
                WHERE deleted = 0 AND customer_phone = @phone 
                ORDER BY created_time DESC";

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<Booking>(query, param);
            return result.ToList();
        }

        public async Task<List<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var param = new DynamicParameters();
            param.Add("@start_date", startDate);
            param.Add("@end_date", endDate);

            string query = @"
                SELECT * FROM booking 
                WHERE deleted = 0 
                AND departure_date >= @start_date 
                AND departure_date <= @end_date 
                ORDER BY departure_date ASC";

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<Booking>(query, param);
            return result.ToList();
        }

        public async Task<Booking> InsertBookingAsync(Booking booking)
        {
            booking.created_time = DateTime.Now;
            booking.deleted = 0;
            booking.version = 1;
            booking.booking_status = booking.booking_status ?? 0; // 0: Pending, 1: Confirmed, 2: Cancelled

            using UnitOfWork unitOfWork = new UnitOfWork();
            return (Booking)await InsertItemAsync<Booking>(booking, unitOfWork);
        }

        public async Task<int> UpdateBookingAsync(Booking booking)
        {
            booking.updated_time = DateTime.Now;
            
            using UnitOfWork unitOfWork = new UnitOfWork();
            return await UpdateItemAsync<Booking>(booking, unitOfWork);
        }

        public async Task<int> DeleteBookingAsync(int bookingId)
        {
            return await DeleteItemByIdAsync<Booking>(bookingId);
        }

        public async Task<int> UpdateBookingStatusAsync(int bookingId, int status)
        {
            var param = new DynamicParameters();
            param.Add("@booking_id", bookingId);
            param.Add("@status", status);
            param.Add("@updated_time", DateTime.Now);

            string query = @"
                UPDATE booking 
                SET booking_status = @status, 
                    updated_time = @updated_time,
                    version = version + 1
                WHERE booking_id = @booking_id AND deleted = 0
                RETURNING version";

            using UnitOfWork unitOfWork = new UnitOfWork();
            var version = await unitOfWork.Connection.ExecuteScalarAsync<int>(query, param, transaction: unitOfWork.Transaction);
            return version > 0 ? 1 : 0;
        }
    }
}
