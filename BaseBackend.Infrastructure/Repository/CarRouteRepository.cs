using BaseBackend.Domain;
using Dapper;

namespace BaseBackend.Infrastructure.Repository
{
    public interface ICarRouteRepository: IBaseRepo<CarRoute, CarRouteFilter>
    {
    }

    public class CarRouteRepository : BaseRepository, ICarRouteRepository
    {
        public Task<List<CarRoute>> GetPagingAsync(CarRouteFilter? filter, PagingInfo? pagingInfo)
        {
            string query = "SELECT * FROM car_route";
            var param = new DynamicParameters();
            return base.GetPagingAsync<CarRoute>(query, param, pagingInfo!);
        }
        public async Task<CarRoute?> GetByIdAsync(int id)
        {
            return await base.FindByIdAsync<CarRoute>(id);
        }
        public async Task<CarRoute> InsertItemAsync(CarRoute item, IUnitOfWork? unitOfWork = null)
        {
            return await base.InsertItemAsync<CarRoute>(item, unitOfWork);
        }

        public async Task<int> UpdateItemAsync(CarRoute item, IUnitOfWork? unitOfWork = null)
        {
            return await base.UpdateItemAsync(item, unitOfWork);
        }
        public async Task<int> DeleteItemAsync(CarRoute id, IUnitOfWork? unitOfWork = null)
        {
            return await base.DeleteItemByIdAsync<CarRoute>(id, unitOfWork);
        }
    }
}
