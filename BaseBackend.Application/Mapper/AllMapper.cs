using AutoMapper;
using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class AllMapper : Profile
    {
        public AllMapper() 
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<TitleDTO, Title>();
            CreateMap<Title, TitleDTO>();
            CreateMap<Account, AccountDTO>();   
            CreateMap<AccountDTO, Account>();
            CreateMap<CustomerT24, CustomerT24DTO>();
            CreateMap<CustomerT24DTO, CustomerT24>();
        }
    }
}
