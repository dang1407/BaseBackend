using BaseBackend.CacheManager;
using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public class ChapterService: BaseService
    {
        private ChapterRepo _chapterRepo = new ChapterRepo();
        public async Task<Chapter> CreateChapteAsync(Chapter chapter)
        {
            chapter.created_time = DateTime.Now;
            chapter.created_by = UserContext.CurrentUser.UserId;
            chapter.deleted = SharedResource.IsNotDeleteInt;
            chapter.version = SharedResource.FirstVersion;

            await _chapterRepo.InsertItemAsync(chapter, null);
            return chapter;
        }

        public async Task<Chapter> UpdateChapterAsync(Chapter chapter)
        {
            chapter.updated_time = DateTime.Now;
            chapter.updated_by = UserContext.CurrentUser.UserId;

            await _chapterRepo.UpdateItemAsync(chapter, null);
            return chapter;
        }

        public async Task<List<Chapter>> GetPagingAsync(ChapterFilter? filter, PagingInfo? pagingInfo)
        {
            if (filter == null)
                filter = new ChapterFilter();
            if (pagingInfo == null)
                pagingInfo = new PagingInfo();
            return await _chapterRepo.GetPagingAsync(filter, pagingInfo);
        }
    }
}
