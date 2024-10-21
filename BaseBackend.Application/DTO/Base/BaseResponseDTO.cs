using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class BaseResponseDTO
    {
        public List<string> FunctionCodes { get; set; } = new List<string>();
        public int? FundID { get; set; }
        public string? DeviceIDs { get; set; } 
        public string? ApprovalToken { get; set; } 
        public string? UCToken { get; set; } 
        public string? UserActionToken { get; set; } 
        public string? IntegrateQueueToken { get; set; } 
        public string? CommentUCToken { get; set; } 
        public string? FundSelectorUC { get; set; } 
        public string? ECM_UCToken { get; set; } 
        public string? UCUploadToken { get; set; } 
        public string? DeclarationUCToken { get; set; } 
        public string? ConfirmationUCToken { get; set; } 
    }
}
