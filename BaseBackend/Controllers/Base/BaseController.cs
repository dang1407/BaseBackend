using BaseBackend.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        private string _functionCode = "";
        protected string ActionCode
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_functionCode))
                {
                    Microsoft.Extensions.Primitives.StringValues lstValue;

                    if (Request.Headers.TryGetValue("X-Action-Code", out lstValue))
                    {
                        _functionCode = lstValue.FirstOrDefault() ?? "";
                    }
                }

                if (string.IsNullOrWhiteSpace(_functionCode))
                {
                    throw new ExecuteErrorException("Header error");
                }

                return _functionCode;
            }
        }

        public class BaseDTO
        {
            public PagingInfo? PagingInfo { get; set; }
        }

        public class BaseApiActionCode
        {
            public const string SetupViewForm = "SetupViewForm";
            public const string SearchData = "SearchData";
            public const string SetupAddNewForm = "SetupAddNewForm";
            public const string AddNewItem = "AddNewItem";
            public const string SetupUpdateForm = "SetupUpdateForm";
            public const string UpdateItem = "UpdateItem";
            public const string SetupDisplay = "SetupDisplay";
            public const string DeleteItem = "DeleteItem";
            public const string SendEmail = "SendEmail";
            public const string DownloadFile = "DownloadFile";
            public const string RequestForAppoval = "RequestForAppoval";
            public const string SetupBeforeApprove = "SetupBeforeApprove";
            public const string Approve = "Approve";
            public const string Reject = "Reject";
            public const string Cancel = "Cancel";
        }
    }
}
