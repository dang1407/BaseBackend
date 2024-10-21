using BaseBackend.Application;
using BaseBackend.Domain;
using BaseBackend.Domain.Constant;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Infrastructure
{
    public class AccountRepository : BaseRepository<Account, AccountFilter, Guid>, IAccountRepository
    {
        public AccountRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public override async Task<List<Account>> GetPaging(PagingInfo pagingInfo, AccountFilter filter)
        {
            string query = $"SELECT * FROM ACCOUNT WHERE Deleted = {SharedResource.IsNotDelete}";
            if (!string.IsNullOrWhiteSpace(filter.UserName)) 
            {
                query += " AND UserName = @UserName ";
            }
            query += $@" LIMIT {pagingInfo.PageSize} OFFSET {pagingInfo.PageIndex * pagingInfo.PageSize};";
            var param = new DynamicParameters();
            param.Add("@UserName", filter.UserName);
            var result = await Uow.Connection.QueryAsync<Account>(query, param);
            return result.ToList();
        }
    }
}
