using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public class PermisionService 
    {
        private readonly PermisionRepository _permisionRepository = new PermisionRepository();
        public PermisionService() 
        {
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
            int isValid = GlobalCache.ListPagePermisions.Where(p => p.feature_id == pageId).Select(p => p.function_code == funcCode).ToList().Count;
            if (isValid == 0) 
            {
                throw new InvalidInputException("Bạn không có quyền truy cập địa chỉ này!");
            }
        }
    }
}
