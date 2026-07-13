using BaseBackend.CacheManager;
using BaseBackend.Domain;
using BaseBackend.Infrastructure;
using BaseBackend.Infrastructure.Repository;

namespace BaseBackend.Application
{
    public interface ICarRouteService : IBaseService<CarRoute, CarRouteFilter>
    {
    }
    public class CarRouteService : BaseService, ICarRouteService
    {
        private readonly ICarRouteRepository _carRouteRepo;
        public CarRouteService(ICarRouteRepository carRouteRepo)
        {
            _carRouteRepo = carRouteRepo;
        }

        public Task<CarRoute?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CarRoute>> GetPagingAsync(CarRouteFilter? filter, PagingInfo? pagingInfo)
        {
            return await _carRouteRepo.GetPagingAsync(filter, pagingInfo);
        }

        public async Task<CarRoute> InsertItemAsync(CarRoute item, IUnitOfWork? unitOfWork = null)
        {
            item.created_by = UserContext.CurrentUser?.Username;
            item.created_time = DateTime.Now;
            return await _carRouteRepo.InsertItemAsync(item, unitOfWork);
        }

        public async Task<int> UpdateItemAsync(CarRoute item, IUnitOfWork? unitOfWork = null)
        {
            item.updated_by = UserContext.CurrentUser?.Username;
            item.updated_time = DateTime.Now;
            return await _carRouteRepo.UpdateItemAsync(item, unitOfWork);
        }

        public async Task<int> DeleteItemAsync(int id, IUnitOfWork? unitOfWork = null)
        {
            CarRoute? item = await GetByIdAsync(id);
            if (item == null) throw new NotFoundException();
            return await _carRouteRepo.DeleteItemAsync(item, unitOfWork);
        }
    }
}
