using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public interface ICarTripService : IBaseService<CarTrip, CarTripFilter>
    {
    }

    public class RouteService : ICarTripService
    {
        private readonly ICarTripRepository _car_tripRepository;

        public RouteService(ICarTripRepository car_tripRepository)
        {
            _car_tripRepository = car_tripRepository;
        }

        public async Task<CarTrip?> GetRouteByIdAsync(int car_tripId)
        {
            if (car_tripId <= 0)
            {
                throw new InvalidInputException("Route ID không hợp lệ");
            }

            return await _car_tripRepository.GetByIdAsync(car_tripId);
        }

        public async Task<List<CarTrip>> GetAllRoutesAsync()
        {
            return await _car_tripRepository.GetAllRoutesAsync();
        }

        public async Task<List<CarTrip>> GetActiveRoutesAsync()
        {
            return await _car_tripRepository.GetActiveRoutesAsync();
        }

        public async Task<List<CarTrip>> SearchRoutesAsync(string? departure, string? destination)
        {
            return await _car_tripRepository.SearchRoutesAsync(departure, destination);
        }

        public async Task<CarTrip> CreateRouteAsync(CarTrip car_trip)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(car_trip.departure))
            {
                throw new InvalidInputException("Điểm đi không được để trống");
            }

            if (string.IsNullOrWhiteSpace(car_trip.destination))
            {
                throw new InvalidInputException("Điểm đến không được để trống");
            }

            if (car_trip.base_price == null || car_trip.base_price <= 0)
            {
                throw new InvalidInputException("Giá cơ bản phải lớn hơn 0");
            }

            return await _car_tripRepository.InsertItemAsync(car_trip);
        }

        public async Task<int> UpdateRouteAsync(CarTrip car_trip)
        {
            if (car_trip.car_trip_id == null || car_trip.car_trip_id <= 0)
            {
                throw new InvalidInputException("Route ID không hợp lệ");
            }

            var existingRoute = await _car_tripRepository.GetByIdAsync(car_trip.car_trip_id.Value);
            if (existingRoute == null)
            {
                throw new ExecuteErrorException("Tuyến đường không tồn tại");
            }

            return await _car_tripRepository.UpdateItemAsync(car_trip);
        }

        public async Task<int> DeleteItemAsync(int car_tripId, IUnitOfWork? unitOfWork)
        {
            if (car_tripId <= 0)
            {
                throw new InvalidInputException("Route ID không hợp lệ");
            }

            var existingRoute = await _car_tripRepository.GetByIdAsync(car_tripId);
            if (existingRoute == null)
            {
                throw new ExecuteErrorException("Tuyến đường không tồn tại");
            }

            return await _car_tripRepository.DeleteItemAsync(existingRoute, unitOfWork);
        }

        public async Task<List<CarTrip>> GetPagingAsync(CarTripFilter? filter, PagingInfo? pagingInfo)
        {
            return await _car_tripRepository.GetPagingAsync(filter, pagingInfo);
        }

        public async Task<CarTrip?> GetByIdAsync(int id)
        {
            return await _car_tripRepository.GetByIdAsync(id);
        }

        public async Task<CarTrip> InsertItemAsync(CarTrip item, IUnitOfWork? unitOfWork = null)
        {
            return await _car_tripRepository.InsertItemAsync(item, unitOfWork);
        }

        public async Task<int> UpdateItemAsync(CarTrip item, IUnitOfWork? unitOfWork = null)
        {
            return await _car_tripRepository.UpdateItemAsync(item, unitOfWork);
        }

        public async Task<int> DeleteItemAsync(CarTrip id, IUnitOfWork? unitOfWork = null)
        {
            return await _car_tripRepository.DeleteItemAsync(id, unitOfWork);
        }
    }
}
