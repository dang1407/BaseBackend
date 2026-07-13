using BaseBackend.Domain;
using Dapper;

namespace BaseBackend.Infrastructure
{
    public interface ICarTripRepository : IBaseRepo<CarTrip, CarTripFilter>
    {
        Task<List<CarTrip>> GetAllRoutesAsync();
        Task<List<CarTrip>> GetActiveRoutesAsync();
        Task<List<CarTrip>> SearchRoutesAsync(string? departure, string? destination);
    }

    public class CarTripRepository : BaseRepository, ICarTripRepository
    {
        public async Task<CarTrip?> GetByIdAsync(int car_tripId)
        {
            return await FindByIdAsync<CarTrip>(car_tripId);
        }

        public async Task<List<CarTrip>> GetAllRoutesAsync()
        {
            string query = @"
                SELECT * FROM car_trip 
                WHERE deleted = 0 
                ORDER BY departure, destination";

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<CarTrip>(query);
            return result.ToList();
        }

        public async Task<List<CarTrip>> GetActiveRoutesAsync()
        {
            string query = @"
                SELECT * FROM car_trip 
                WHERE deleted = 0 AND status = 1 
                ORDER BY departure, destination";

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<CarTrip>(query);
            return result.ToList();
        }

        public async Task<List<CarTrip>> SearchRoutesAsync(string? departure, string? destination)
        {
            var param = new DynamicParameters();
            string query = @"
                SELECT * FROM car_trip 
                WHERE deleted = 0 AND status = 1";

            if (!string.IsNullOrEmpty(departure))
            {
                query += " AND LOWER(departure) LIKE LOWER(@departure)";
                param.Add("@departure", $"%{departure}%");
            }

            if (!string.IsNullOrEmpty(destination))
            {
                query += " AND LOWER(destination) LIKE LOWER(@destination)";
                param.Add("@destination", $"%{destination}%");
            }

            query += " ORDER BY departure, destination";

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<CarTrip>(query, param);
            return result.ToList();
        }

        public async Task<int> DeleteItemAsync(CarTrip car_tripId, IUnitOfWork? unitOfWork)
        {
            return await DeleteItemByIdAsync<CarTrip>(car_tripId, unitOfWork);
        }

        public Task<List<CarTrip>> GetPagingAsync(CarTripFilter? filter, PagingInfo? pagingInfo)
        {
            throw new NotImplementedException();
        }

        public async Task<CarTrip> InsertItemAsync(CarTrip item, IUnitOfWork? unitOfWork = null)
        {
            return await base.InsertItemAsync<CarTrip>(item, unitOfWork);   
        }

        public async Task<int> UpdateItemAsync(CarTrip item, IUnitOfWork? unitOfWork = null)
        {
            return await base.UpdateItemAsync(item, unitOfWork);
        }

        public async Task<int> DeleteItemAsync(int id, IUnitOfWork? unitOfWork = null)
        {
            return await base.DeleteItemByIdAsync<CarTrip>(id, unitOfWork);
        }
    }
}
