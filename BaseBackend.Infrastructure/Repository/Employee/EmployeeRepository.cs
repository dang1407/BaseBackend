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
    public class EmployeeRepository : BaseRepository<Employee, EmployeeFilter, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork) 
        { }

        public override async Task<List<Employee>> GetPaging(PagingInfo pagingInfo, EmployeeFilter filter)
        {
            string sql = 
            $@"
                SELECT E.*
                FROM EMPLOYEE E
                WHERE E.DELETED = {SharedResource.IsNotDelete}
            ";
            if(!string.IsNullOrWhiteSpace(filter.EmployeeCode))
            {
                sql += " \n AND E.EmployeeCode = @EmployeeCode ";
            }

            sql += $@" LIMIT {pagingInfo.PageSize} OFFSET {pagingInfo.PageIndex * pagingInfo.PageSize};";
            var param = new DynamicParameters();
            param.Add("@EmployeeCode", filter.EmployeeCode);
            var result = await Uow.Connection.QueryAsync<Employee>(sql, param);
            return result.ToList();
        }
    }
}
