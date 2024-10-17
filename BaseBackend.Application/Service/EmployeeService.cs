using AutoMapper;
using BaseBackend.Application.IService;
using BaseBackend.Domain;
using BaseBackend.Domain.Filter;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class EmployeeService : BaseService<Employee, EmployeeDTO, EmployeeDTO, EmployeeDTO, EmployeeFilter>, IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository baseRepository, IMapper mapper) : base(baseRepository, mapper)
        {
            _repository = baseRepository;
        }

        public async Task<List<EmployeeDTO>> GetPaging(PagingInfo pagingInfo, EmployeeFilter filter)
        {
            List<Employee> listEmployee = await _repository.GetPaging(pagingInfo, filter);
            List<EmployeeDTO> listEmployeeDTO = listEmployee.Select(e => Mapper.Map<EmployeeDTO>(e)).ToList();
            return listEmployeeDTO;
        }
    }
}
