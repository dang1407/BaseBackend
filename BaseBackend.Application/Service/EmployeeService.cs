using AutoMapper;
using BaseBackend.Application.IService;
using BaseBackend.Domain;
using BaseBackend.Domain.Constant;
using BaseBackend.Domain.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BaseBackend.Application
{
    public class EmployeeService : BaseService<Employee, EmployeeDTO, EmployeeFilter, Guid>, IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository baseRepository, IMapper mapper, IMemoryCache memoryCache) : base(baseRepository, mapper, memoryCache)
        {
            _repository = baseRepository;
        }

        public async Task<int> InsertEmployeeWithDepartment(List<Employee> employees, List<Employee> employees1)
        {
            using (var trans = new TransactionScope()) 
            {
                await _repository.InsertManyAsync(employees);
                await _repository.InsertManyAsync(employees1);
                trans.Complete();
                return employees1.Count() + employees.Count();
            }
        }

        public override async Task ValidateCreateBusinessAsync(Employee entity)
        {
            PagingInfo pagingInfo = new PagingInfo();
            EmployeeFilter filter = new EmployeeFilter();
            filter.EmployeeCode = entity.EmployeeCode ?? "";
            List<Employee> existEmp = await _repository.GetPaging(pagingInfo, filter);
            if (existEmp.Count > 0) 
            {
                throw new ConflictException("EmployeeCode đã tồn tại");
            }
        }
    }
}
