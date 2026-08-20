using BaseBackend.Domain;
using Dapper;

namespace BaseBackend.Infrastructure {
    public interface INovelRepo : IBaseRepo<Novel, NovelFilter>
    {
    }

    public class NovelRepo : BaseRepository, INovelRepo
    {

        public async Task<int> DeleteItemAsync(Novel item, IUnitOfWork? unitOfWork = null)
        {
            return await base.DeleteItemByIdAsync<Novel>(item.novel_id);
        }

        public async Task<Novel?> GetByIdAsync(int id)
        {
            return await base.FindByIdAsync<Novel>(id);
        }

        public async Task<List<Novel>> GetPagingAsync(NovelFilter? filter, PagingInfo? pagingInfo)
        {
            string query = "select * from novel n where n.deleted = @is_not_deleted";
            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.title)) query += " and n.title ilike @title";
                if (!string.IsNullOrWhiteSpace(filter.status)) query += " and n.status = @status";
                if (!string.IsNullOrWhiteSpace(filter.genre)) query += " and n.genres ilike @genre";
                if (filter.author_id.HasValue) query += " and n.author_id = @author_id";
            }
            query += " order by n.novel_id desc limit @page_size offset @offset";

            DynamicParameters param = new DynamicParameters();
            if (filter != null)
            {
                param.Add("@title", BuildLikeFilter(filter.title));
                param.Add("@status", filter.status);
                param.Add("@genre", BuildLikeFilter(filter.genre));
                param.Add("@author_id", filter.author_id);
            }
            param.Add("@offset", pagingInfo!.PageIndex * pagingInfo.PageSize);
            param.Add("@page_size", pagingInfo.PageSize);
            param.Add("@is_not_deleted", SharedResource.IsNotDeleteInt);

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<Novel>(query, param);
            return result.ToList();
        }

        public async Task<Novel> InsertItemAsync(Novel item, IUnitOfWork? unitOfWork)
        {
            return (Novel)await base.InsertItemAsync<Novel>(item, unitOfWork);
        }

        public Task<int> UpdateItemAsync(Novel item, IUnitOfWork? unitOfWork)
        {
            return base.UpdateItemAsync<Novel>(item, unitOfWork);
        }
    }
}
