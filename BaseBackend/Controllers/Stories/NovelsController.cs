using BaseBackend.Application;
using BaseBackend.Domain;
using BaseBackend.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers.Stories
{
    [AllowAnonymous]
    public class NovelsController : BaseController
    {
        private readonly INovelService _novelService;

        public NovelsController(INovelService novelRepo)
        {
            _novelService = novelRepo;
        }

        [HttpPost]
        public async Task<NovelDTO> Post(NovelDTO request)
        {
            NovelDTO response = new NovelDTO();
            switch (this.ActionCode)
            {
                case BaseApiActionCode.SearchData:
                    {
                        response.Novels = await _novelService.GetPagingAsync(request.Filter, request.PagingInfo);
                        break;
                    }
                case "GetMyNovels":
                    {
                        response.Novels = await _novelService.GetMyNovelAsync(request.Filter, request.PagingInfo);
                        break;
                    }
                case BaseApiActionCode.AddNewItem:
                    {
                        response.Novel = await _novelService.AddNewNodelAsync(request.Novel);
                        break;
                    }
                default:
                    throw new NotImplementedException(ActionCode);
            }
            return response;
        }

        public class NovelDTO : BaseDTO
        {
            public List<Novel>? Novels { get; set; }
            public NovelFilter? Filter { get; set; }
            public Novel? Novel { get; set; }
            public Chapter? Chapter { get; set; }
        }
        
    }
}
