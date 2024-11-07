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
    public class PermisionRepository : IPermisionRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermisionRepository(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public List<string> GetPageItemPermision(int pageId, int itemId, string funcCode)
        {
            throw new NotImplementedException();
        }

        public List<FunctionRight> GetAllPagePermision()
        {
            string sql = @"
SELECT 
    a.FeatureId,
    a2.Code AS FunctionCode,
    a2.FunctionId
FROM 
    AdmFeature a 
    INNER JOIN AdmFeatureFunction a1 ON a.FeatureId = a1.FeatureId
    INNER JOIN AdmFunction a2 on a1.FunctionId = a2.FunctionId
WHERE a2.Deleted = 0 
                ";
            var param = new DynamicParameters();
            List<FunctionRight> result = _unitOfWork.Connection.Query<FunctionRight>(sql, param).ToList();
            return result;
        }
    }
}
