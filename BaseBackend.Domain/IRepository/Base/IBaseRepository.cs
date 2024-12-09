using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public interface IBaseRepository<TEntity, TFilter> where TFilter : BaseFilter where TEntity : BaseEntity
    {

        Task<List<TEntity>> GetPagingAsync(PagingInfo pagingInfo, TFilter filter);

        Task<TEntity?> FindByIdAsync(int id);
        /// <summary>
        /// Hàm lấy thông tin Entity theo Id
        /// </summary>
        /// <param name="id">Định danh của Entity (Guid)</param>
        /// <returns>Thông tin Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (19/09/2023)
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Hàm lấy thông tin nhiều Entity theo Id
        /// </summary>
        /// <param name="ids">Định danh của các Entity (Guid)</param>
        /// <returns>Thông tin các Entity nếu thành công, null nếu thất bại</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<List<TEntity>> GetByListIdAsync(List<int> ids);   

        /// <summary>
        /// Hàm thêm mới một Entity
        /// </summary>
        /// <param name="entity">Instance của Entity</param>
        /// <returns>Thông tin Entity đã thêm thành công</returns>
        /// Created by: nkmdang (20/09/2023)
        abstract Task<TEntity> InsertAsync(TEntity entity);

        abstract int Insert(TEntity entity);

        /// <summary>
        /// Hàm thêm mới nhiều Entity
        /// </summary>
        /// <param name="entities">Instances của Entity</param>
        /// <returns>Thông tin các Entity đã thêm thành công</returns>
        /// Created by: nkmdang (20/09/2023)
        abstract Task<List<TEntity>> InsertManyAsync(List<TEntity> entities);

        /// <summary>
        /// Hàm sửa thông tin một Entity
        /// </summary>
        /// <param name="entity">Instance của Entity</param>
        /// <returns>Thông tin của Entity sau khi đã thay đổi</returns>
        /// Created by: nkmdang (20/09/2023)
        abstract Task<TEntity> UpdateAsync(TEntity entity);
        abstract int Update(TEntity entity);
        abstract Task<int> UpdateManyAsync(List<TEntity> entities);

        /// <summary>
        /// Hàm cập nhật Deleted = 1 thông tin một Entity
        /// </summary>
        /// <param name="id">Định danh Entity</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<int> SoftDeleteAsync(int id);

        int SoftDelete(int id);
        /// <summary>
        /// Hàm cập nhật Deleted = 1 thông tin một Entity
        /// </summary>
        /// <param name="id">Định danh Entity</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<int> SoftDeleteManyAsync(List<int> ids);
        int SoftDeleteMany(List<int> ids);

        /// <summary>
        /// Hàm xóa thông tin một Entity
        /// </summary>
        /// <param name="id">Định danh Entity</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<int> DeleteAsync(int id);
        int DeleteById(int id);
        /// <summary>
        /// Hàm xóa thông tin nhiều Entity
        /// </summary>
        /// <param name="ids">Danh sách các dịnh danh Entity</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: nkmdang (20/09/2023)
        Task<int> DeleteManyAsync(List<int> ids);

        int DeleteManyByIds(List<int> ids);
    }
}
