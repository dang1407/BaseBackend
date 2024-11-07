using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public interface IBaseReadOnlyService<TDTO, TFilter, TIdKey> where TFilter : BaseFilter
    {
        /// <summary>
        /// Hàm lấy ra tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<List<TDTO>> GetPaging(PagingInfo pagingInfo, TFilter filter);


        /// <summary>
        /// Hàm tìm kiếm Entity theo Id
        /// </summary>
        /// <param name="id">Định danh của Entity (Guid)</param>
        /// <returns>Thông tin Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<TDTO> FindByIdAsync(TIdKey id);

        /// <summary>
        /// Hàm lấy thông tin Entity theo Id
        /// </summary>
        /// <param name="id">Định danh của Entity (Guid)</param>
        /// <returns>Thông tin Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<TDTO> GetByIdAsync(TIdKey id);
        void CheckPagePermision(int? pageId, string funcCode);
    }
}
