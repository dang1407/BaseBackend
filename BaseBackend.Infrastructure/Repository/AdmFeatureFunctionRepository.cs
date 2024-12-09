using BaseBackend.Application;
using BaseBackend.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Infrastructure
{
    public class AdmFeatureFunctionRepository : BaseRepository<AdmFeatureFunction, AdmFeatureFunctionFilter>, IAdmFeatureFunctionRepository
    {
        public AdmFeatureFunctionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<string> CheckPagePermision(int pageId, string funcCode)
        {
            throw new NotImplementedException();
        }

        public override async Task<List<AdmFeatureFunction>> GetPagingAsync(PagingInfo pagingInfo, AdmFeatureFunctionFilter filter)
        {
            string query = $@"SELECT * FROM AdmFeatureFunction WHERE 1 = 1 ";
            if(filter.FeatureId.HasValue)
            {
                query += " \n AND FeatureId = @FeatureId ";
            }
            var param = new DynamicParameters();
            param.Add("@FeatureId", filter.FeatureId);

            var result = await Uow.Connection.QueryAsync<AdmFeatureFunction>(query, param);
            return result.ToList();
        }
    }
}
