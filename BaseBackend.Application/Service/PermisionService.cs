using BaseBackend.Application.IService;
using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class PermisionService : IPermisionService
    {
        private readonly IPermisionRepository _permisionRepository;
        public PermisionService(IPermisionRepository permisionRepository) 
        {
            _permisionRepository = permisionRepository;
        }

        public List<FunctionRight> GetAllPagePermisions()
        {
            List<FunctionRight> result = _permisionRepository.GetAllPagePermision();
            return result;
        }

        public List<string> GetItemPermisions(int pageId, int itemId, string funcCode)
        {
            throw new NotImplementedException();
        }

        public void CheckPagePermisions(int pageId, string funcCode)
        {
            int isValid = GlobalCache.ListPagePermisions.Where(p => p.FeatureId == pageId).Select(p => p.FunctionCode == funcCode).ToList().Count;
            if (isValid == 0) 
            {
                throw new InvalidException("Bạn không có quyền truy cập địa chỉ này!");
            }
        }
    }
}
