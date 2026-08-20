using BaseBackend.CacheManager;
using BaseBackend.Domain;
using BaseBackend.Domain.Entity.Stories;
using BaseBackend.Infrastructure;

namespace BaseBackend.Application
{
    public interface INovelService : IBaseService<Novel, NovelFilter>
    {
        public Task<Novel> AddNewNodelAsync(Novel novel);
        public Task<List<Novel>> GetMyNovelAsync(NovelFilter? filter, PagingInfo? pagingInfo);
    }
    public class NovelService : BaseService, INovelService
    {
        private INovelRepo _novelRepo;
        private BaseRepository baseRepo = new BaseRepository();
        public NovelService(INovelRepo repo) : base()
        {
            _novelRepo = repo;
        }
        public async Task<int> DeleteItemAsync(int id, IUnitOfWork? unitOfWork = null)
        {
            var existNovel = await _novelRepo.GetByIdAsync(id);
            if (existNovel != null)
            {
                return await _novelRepo.DeleteItemAsync(existNovel);
            }
            return 0;
        }

        public async Task<Novel?> GetByIdAsync(int id)
        {
            return await _novelRepo.GetByIdAsync(id);
        }

        public async Task<List<Novel>> GetPagingAsync(NovelFilter? filter, PagingInfo? pagingInfo)
        {
            var novels = await _novelRepo.GetPagingAsync(filter, pagingInfo);
            novels.ForEach(novel =>
            {
                novel.genres_array = novel.genres?.Split(",");
            });
            return novels;
        }

        public async Task<Novel> InsertItemAsync(Novel item, IUnitOfWork? unitOfWork = null)
        {
            return await _novelRepo.InsertItemAsync(item, unitOfWork);
        }

        public async Task<int> UpdateItemAsync(Novel item, IUnitOfWork? unitOfWork = null)
        {
            return await _novelRepo.UpdateItemAsync(item, unitOfWork);
        }


        public async Task<Novel> AddNewNodelAsync(Novel novel)
        {
            UserNovel userNovel = new UserNovel()
            {
                user_id = UserContext.CurrentUser.UserId
            };
            novel.author_id = UserContext.CurrentUser.UserId;
            novel.deleted = SharedResource.IsNotDeleteInt;
            novel.version = SharedResource.FirstVersion;
            novel.created_time = DateTime.Now;
            novel.created_by = UserContext.CurrentUser.UserId;
            using (var unitOfWork = new UnitOfWork())
            {
                try
                {
                    await unitOfWork.BeginTransactionAsync();
                    await baseRepo.InsertItemAsync(novel, unitOfWork);
                    userNovel.novel_id = novel.novel_id;
                    await unitOfWork.CommitAsync();
                    return novel;
                }
                catch (Exception ex)
                {
                    await unitOfWork.RollBackAsync();
                    throw new ExecuteErrorException("Lỗi thêm mới truyện");
                }
            }
        }

        public async Task<List<Novel>> GetMyNovelAsync(NovelFilter? filter, PagingInfo? pagingInfo)
        {
            if (filter == null)
                filter = new NovelFilter();
            if (pagingInfo == null)
                pagingInfo = new PagingInfo();
            filter.author_id = UserContext.CurrentUser.UserId;
            pagingInfo.PageSize = 100000;
            return await GetPagingAsync(filter, pagingInfo);
        }

    }
}
