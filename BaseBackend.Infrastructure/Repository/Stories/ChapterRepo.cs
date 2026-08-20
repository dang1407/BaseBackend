using BaseBackend.Domain;
using Dapper;

namespace BaseBackend.Infrastructure
{
    public class ChapterRepo : BaseRepository
    {
        public async Task<List<Chapter>> GetPagingAsync(ChapterFilter? filter, PagingInfo? pagingInfo)
        {
            string query = "select * from chapter c where c.deleted = @is_not_deleted";
            if (filter != null && filter.novel_id.HasValue) query += " and c.novel_id = @novel_id";
            query += " order by c.chapter_number asc limit @page_size offset @offset";

            DynamicParameters param = new DynamicParameters();
            if (filter != null) param.Add("@novel_id", filter.novel_id);
            param.Add("@offset", pagingInfo!.PageIndex * pagingInfo.PageSize);
            param.Add("@page_size", pagingInfo.PageSize);
            param.Add("@is_not_deleted", SharedResource.IsNotDeleteInt);

            using UnitOfWork unitOfWork = new UnitOfWork();
            var result = await unitOfWork.Connection.QueryAsync<Chapter>(query, param);
            return result.ToList();
        }
    }
}
