using BaseBackend.Application;
using BaseBackend.Domain;
using BaseBackend.Domain.Constant;
using BaseBackend.Domain.Filter;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Infrastructure
{
    public class TitleRepository : BaseRepository<Title, TitleFilter, Guid>, ITitleRepository
    {
        public TitleRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public override async Task<List<Title>> GetPagingAsync(PagingInfo pagingInfo, TitleFilter filter)
        {
            string query = $@"
                SELECT t.* FROM title t WHERE t.Deleted = {SharedResource.IsNotDelete}
            ";
            query += $@" LIMIT {pagingInfo.PageSize} OFFSET {pagingInfo.PageIndex * pagingInfo.PageSize};";

            var param = new DynamicParameters();
            var titles = await Uow.Connection.QueryAsync<Title>(query, param);
            return titles.ToList();
        }
    }
}
