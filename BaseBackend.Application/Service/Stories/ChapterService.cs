using BaseBackend.CacheManager;
using BaseBackend.Domain;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public class ChapterService : BaseService
    {
        private ChapterRepo _chapterRepo = new ChapterRepo();
        public async Task<Chapter> CreateChapteAsync(Chapter chapter)
        {
            if (chapter.novel_id == null) throw new InvalidDataException("Dữ liệu không hợp lệ");

            chapter.created_time = DateTime.Now;
            chapter.created_by = UserContext.CurrentUser.UserId;
            chapter.deleted = SharedResource.IsNotDeleteInt;
            chapter.version = SharedResource.FirstVersion;
            using UnitOfWork unitOfWork = new UnitOfWork();
            var novel = await _chapterRepo.FindByIdAsync<Novel>(chapter.novel_id);
            if(novel == null ) throw new InvalidDataException("Dữ liệu không hợp lệ");
            novel.chapters_count = novel.chapters_count + 1;
            try
            {
                await unitOfWork.BeginTransactionAsync();
                await _chapterRepo.InsertItemAsync(chapter, unitOfWork);
                await _chapterRepo.UpdateItemAsync(novel, unitOfWork);
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await unitOfWork.RollBackAsync();
            }

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

        public async Task IncreaseViewCountAsync(int chapterId)
        {
            await _chapterRepo.IncreaseViewCountAsync(chapterId);
        }
    }
}
