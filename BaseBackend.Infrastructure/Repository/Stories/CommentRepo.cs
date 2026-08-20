using BaseBackend.Domain;
using Dapper;

namespace BaseBackend.Infrastructure
{
    public interface ICommentRepo : IBaseRepo<Comment, CommentFilter>
    {
        Task<List<Comment>> GetByNovelOrChapterAsync(int novelId, int? chapterId);
    }

    public class CommentRepo : BaseRepository, ICommentRepo
    {

        public async Task<int> DeleteItemAsync(Comment item, IUnitOfWork? unitOfWork = null)
        {
            return await base.DeleteItemByIdAsync<Comment>(item.comment_id);
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await base.FindByIdAsync<Comment>(id);
        }

        public async Task<List<Comment>> GetByNovelOrChapterAsync(int novelId, int? chapterId)
        {
            string query = "select * from comment where novel_id = @novel_id and deleted = @is_not_deleted";
            if (chapterId.HasValue) query += " and chapter_id = @chapter_id";
            query += " order by created_time desc";

            DynamicParameters param = new DynamicParameters();
            param.Add("@novel_id", novelId);
            param.Add("@chapter_id", chapterId);
            param.Add("@is_not_deleted", SharedResource.IsNotDeleteInt);

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<Comment>(query, param);
            return result.ToList();
        }

        public async Task<List<Comment>> GetPagingAsync(CommentFilter? filter, PagingInfo? pagingInfo)
        {
            string query = "select * from comment c where c.deleted = @is_not_deleted";
            if (filter != null)
            {
                if (filter.novel_id.HasValue) query += " and c.novel_id = @novel_id";
                if (filter.chapter_id.HasValue) query += " and c.chapter_id = @chapter_id";
            }
            query += " order by c.comment_id desc limit @page_size offset @offset";

            DynamicParameters param = new DynamicParameters();
            if (filter != null)
            {
                param.Add("@novel_id", filter.novel_id);
                param.Add("@chapter_id", filter.chapter_id);
            }
            param.Add("@offset", pagingInfo!.PageIndex * pagingInfo.PageSize);
            param.Add("@page_size", pagingInfo.PageSize);
            param.Add("@is_not_deleted", SharedResource.IsNotDeleteInt);

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<Comment>(query, param);
            return result.ToList();
        }

        public async Task<Comment> InsertItemAsync(Comment item, IUnitOfWork? unitOfWork)
        {
            return (Comment)await base.InsertItemAsync<Comment>(item, unitOfWork);
        }

        public Task<int> UpdateItemAsync(Comment item, IUnitOfWork? unitOfWork)
        {
            return base.UpdateItemAsync<Comment>(item, unitOfWork);
        }
    }
}
