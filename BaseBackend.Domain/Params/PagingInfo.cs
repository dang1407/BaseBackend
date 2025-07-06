namespace BaseBackend.Domain
{
    public class PagingInfo
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = SharedResource.DefaultPageSize;
    }
}
