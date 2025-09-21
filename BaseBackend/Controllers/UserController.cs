using BaseBackend.Application;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers
{
    public class UserController : BaseController
    {
        private readonly adm_userService _userService = new adm_userService();
        private adm_userDTO dtoRespone = new adm_userDTO();
        [HttpPost]
        public adm_userDTO Post(adm_userDTO requestDTO)
        {
            adm_userDTO dtoResponse = new adm_userDTO();
            switch (this.ActionCode)
            {
                case ApiActionCode.SearchData:
                    {
                        dtoRespone.adm_users = _userService.GetPaging(requestDTO.Filter, requestDTO.PagingInfo);
                        break;
                    }
                case ApiActionCode.UpdateItem:
                    {
                        _userService.UpdateUser(requestDTO.adm_user); 
                        break;
                    }
                case ApiActionCode.AddNewItem:
                    {
                        _userService.InsertUser(requestDTO.adm_user);
                        break;
                    }
                default:
                    throw new NotImplementedException("ActionCode isn't supported.");
            }
            return dtoRespone;
        }

        public class adm_userDTO
        {
            public adm_userFilter Filter { get; set; } = new adm_userFilter();
            public PagingInfo PagingInfo { get; set; } = new PagingInfo();
            public List<adm_user>? adm_users { get; set; }
            public adm_user? adm_user { get; set; }
        }

        public class ApiActionCode : BaseApiActionCode
        {

        }
    }
}
