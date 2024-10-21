using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public interface IBaseService<TDTO,TFilter, TIdKey> : IBaseReadOnlyService<TDTO, TFilter, TIdKey> where TFilter : BaseFilter
    {
        /// <summary>
        /// Hàm thêm mới một TDTO
        /// </summary>
        /// <param name="createDTO">Instance của TDTO</param>
        /// <returns>Thông tin TDTO đã thêm thành công</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<TDTO> InsertAsync(TDTO createDTO, CachedUserInfo cachedUserInfo);


        /// <summary>
        /// Hàm thêm mới nhiều TDTO
        /// </summary>
        /// <param name="createDTOs">Instances của TDTO</param>
        /// <returns>Thông tin các TDTO đã thêm thành công</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<int> InsertManyAsync(List<TDTO> createDTOs, CachedUserInfo cachedUserInfo);

        /// <summary>
        /// Hàm sửa thông tin một TDTO
        /// </summary>
        /// <param name="updateDTO">Instance của TDTO</param>
        /// <returns>Thông tin của TDTO sau khi đã thay đổi</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<int> UpdateAsync(TIdKey id, TDTO updateDTO, CachedUserInfo cachedUserInfo);

        Task<int> UpdateManyAsync(List<TDTO> entities, CachedUserInfo cachedUserInfo);

        /// <summary>
        /// Hàm xóa thông tin một TDTO
        /// </summary>
        /// <param name="id">Định danh TDTO</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<int> DeleteAsync(TIdKey id, CachedUserInfo cachedUserInfo);

        /// <summary>
        /// Hàm xóa thông tin nhiều TDTO
        /// </summary>
        /// <param name="ids">Danh sách các dịnh danh TDTO</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<int> DeleteManyAsync(List<TIdKey> ids, CachedUserInfo cachedUserInfo);
    }
}
