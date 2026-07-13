using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public interface IBookingService
    {
        Task<Booking?> GetBookingByIdAsync(int bookingId);
        Task<List<Booking>> GetAllBookingsAsync();
        Task<List<Booking>> GetBookingsByRouteIdAsync(int car_tripId);
        Task<List<Booking>> GetBookingsByPhoneAsync(string phone);
        Task<List<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<int> UpdateBookingAsync(Booking booking);
        Task<int> DeleteBookingAsync(int bookingId);
        Task<int> ConfirmBookingAsync(int bookingId);
        Task<int> CancelBookingAsync(int bookingId);
    }

    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICarTripRepository _car_tripRepository;

        public BookingService(IBookingRepository bookingRepository, ICarTripRepository car_tripRepository)
        {
            _bookingRepository = bookingRepository;
            _car_tripRepository = car_tripRepository;
        }

        public async Task<Booking?> GetBookingByIdAsync(int bookingId)
        {
            if (bookingId <= 0)
            {
                throw new InvalidInputException("Booking ID không hợp lệ");
            }

            return await _bookingRepository.GetByIdAsync(bookingId);
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllBookingsAsync();
        }

        public async Task<List<Booking>> GetBookingsByRouteIdAsync(int car_tripId)
        {
            if (car_tripId <= 0)
            {
                throw new InvalidInputException("Route ID không hợp lệ");
            }

            return await _bookingRepository.GetBookingsByRouteIdAsync(car_tripId);
        }

        public async Task<List<Booking>> GetBookingsByPhoneAsync(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new InvalidInputException("Số điện thoại không được để trống");
            }

            return await _bookingRepository.GetBookingsByPhoneAsync(phone);
        }

        public async Task<List<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new InvalidInputException("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
            }

            return await _bookingRepository.GetBookingsByDateRangeAsync(startDate, endDate);
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            // Validate customer info
            if (string.IsNullOrWhiteSpace(booking.customer_name))
            {
                throw new InvalidInputException("Tên khách hàng không được để trống");
            }

            if (string.IsNullOrWhiteSpace(booking.customer_phone))
            {
                throw new InvalidInputException("Số điện thoại không được để trống");
            }

            // Validate phone format (basic)
            if (booking.customer_phone.Length < 10)
            {
                throw new InvalidInputException("Số điện thoại không hợp lệ");
            }

            // Validate car_trip
            if (booking.car_trip_id == null || booking.car_trip_id <= 0)
            {
                throw new InvalidInputException("Tuyến đường không hợp lệ");
            }

            var car_trip = await _car_tripRepository.GetByIdAsync(booking.car_trip_id.Value);
            if (car_trip == null)
            {
                throw new ExecuteErrorException("Tuyến đường không tồn tại");
            }

            // Validate departure date
            if (booking.departure_date == null)
            {
                throw new InvalidInputException("Ngày khởi hành không được để trống");
            }

            if (booking.departure_date < DateTime.Now.Date)
            {
                throw new InvalidInputException("Ngày khởi hành phải từ hôm nay trở đi");
            }

            // Validate number of passengers
            if (booking.number_of_passengers == null || booking.number_of_passengers <= 0)
            {
                throw new InvalidInputException("Số lượng hành khách phải lớn hơn 0");
            }

            // Calculate total price if not provided
            if (booking.total_price == null || booking.total_price <= 0)
            {
                booking.total_price = car_trip.base_price * booking.number_of_passengers;
            }

            return await _bookingRepository.InsertBookingAsync(booking);
        }

        public async Task<int> UpdateBookingAsync(Booking booking)
        {
            if (booking.booking_id == null || booking.booking_id <= 0)
            {
                throw new InvalidInputException("Booking ID không hợp lệ");
            }

            var existingBooking = await _bookingRepository.GetByIdAsync(booking.booking_id.Value);
            if (existingBooking == null)
            {
                throw new ExecuteErrorException("Đặt chỗ không tồn tại");
            }

            return await _bookingRepository.UpdateBookingAsync(booking);
        }

        public async Task<int> DeleteBookingAsync(int bookingId)
        {
            if (bookingId <= 0)
            {
                throw new InvalidInputException("Booking ID không hợp lệ");
            }

            var existingBooking = await _bookingRepository.GetByIdAsync(bookingId);
            if (existingBooking == null)
            {
                throw new ExecuteErrorException("Đặt chỗ không tồn tại");
            }

            return await _bookingRepository.DeleteBookingAsync(bookingId);
        }

        public async Task<int> ConfirmBookingAsync(int bookingId)
        {
            if (bookingId <= 0)
            {
                throw new InvalidInputException("Booking ID không hợp lệ");
            }

            var existingBooking = await _bookingRepository.GetByIdAsync(bookingId);
            if (existingBooking == null)
            {
                throw new ExecuteErrorException("Đặt chỗ không tồn tại");
            }

            return await _bookingRepository.UpdateBookingStatusAsync(bookingId, 1); // 1: Confirmed
        }

        public async Task<int> CancelBookingAsync(int bookingId)
        {
            if (bookingId <= 0)
            {
                throw new InvalidInputException("Booking ID không hợp lệ");
            }

            var existingBooking = await _bookingRepository.GetByIdAsync(bookingId);
            if (existingBooking == null)
            {
                throw new ExecuteErrorException("Đặt chỗ không tồn tại");
            }

            return await _bookingRepository.UpdateBookingStatusAsync(bookingId, 2); // 2: Cancelled
        }
    }
}
