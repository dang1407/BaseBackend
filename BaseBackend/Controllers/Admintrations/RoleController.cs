using BaseBackend.Application;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers.Admintrations
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService userService)
        {
            _roleService = userService;
        }

        [HttpPost]
        public async Task<AdmRoleDTO> Post(AdmRoleDTO requestDTO)
        {
            AdmRoleDTO dtoResponse = new AdmRoleDTO();
            switch (this.ActionCode)
            {
                case ApiActionCode.SearchData:
                    {
                        dtoResponse.AdmRoles = await _roleService.GetPaging(requestDTO.Filter, requestDTO.PagingInfo);
                        dtoResponse.PagingInfo = requestDTO.PagingInfo;
                        break;
                    }
                case ApiActionCode.UpdateItem:
                    {
                        AdmRole role = requestDTO.AdmRole?.CloneToUpdate() ?? throw new InvalidInputException(SharedResource.InputDataInvalid);
                        await _roleService.UpdateItem(role);
                        break;
                    }
                case ApiActionCode.AddNewItem:
                    {
                        AdmRole role = requestDTO.AdmRole ?? throw new InvalidInputException(SharedResource.InputDataInvalid);
                        dtoResponse.AdmRole = await _roleService.InsertItem(role);
                        break;
                    }
                case ApiActionCode.SetupDisplay:
                    {
                        if (requestDTO.RoleId.HasValue)
                        {
                            dtoResponse.AdmRole = await _roleService.GetById(requestDTO.RoleId.Value);
                        }
                        break;
                    }
                case ApiActionCode.SetupUpdateForm:
                    {
                        if (requestDTO.RoleId.HasValue)
                        {
                            dtoResponse.AdmRole = await _roleService.GetById(requestDTO.RoleId.Value);
                        }
                        break;
                    }
                default:
                    throw new NotImplementedException("ActionCode isn't supported.");
            }
            return dtoResponse;
        }

        public class ApiActionCode : BaseApiActionCode
        {

        }
    }
    public class AdmRoleDTO
    {
        public AdmRoleFilter? Filter { get; set; }
        public PagingInfo? PagingInfo { get; set; }
        public List<AdmRole>? AdmRoles { get; set; }
        public AdmRole? AdmRole { get; set; }
        public int? RoleId { get; set; }
    }
}
