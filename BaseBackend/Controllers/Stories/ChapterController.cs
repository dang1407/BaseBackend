using BaseBackend.Application;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers.Stories
{
    public class ChapterController : BaseController
    {
        private readonly ChapterService _ChapterService = new ChapterService();

        [HttpPost]
        public async Task<ChapterDTO> Post(ChapterDTO request)
        {
            ChapterDTO response = new ChapterDTO();
            switch (this.ActionCode)
            {
                case BaseApiActionCode.SearchData:
                    {
                        response.Chapters = await _ChapterService.GetPagingAsync(request.Filter, request.PagingInfo);
                        break;
                    }

                case BaseApiActionCode.AddNewItem:
                    {
                        response.Chapter = await _ChapterService.CreateChapteAsync(request.Chapter);
                        break;
                    }
                case BaseApiActionCode.UpdateItem:
                    {
                        response.Chapter = await _ChapterService.UpdateChapterAsync(request.Chapter);
                        break;
                    }
                case "GetChapterByID":
                    {
                        response.Chapter = await _ChapterService.GetItemByIDAsync<Chapter>(request.ChapterID);
                        break;
                    }
                default:
                    throw new NotImplementedException(ActionCode);
            }
            return response;
        }

        public class ChapterDTO : BaseDTO
        {
            public List<Chapter>? Chapters { get; set; }
            public ChapterFilter? Filter { get; set; }
            public Chapter? Chapter { get; set; }
            public int? ChapterID { get; set; }
        }

    }
}
