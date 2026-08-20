namespace BaseBackend.Domain
{
    public class NovelFilter : BaseFilter
    {
        public string? title { get; set; }
        public string? status { get; set; }
        public string? genre { get; set; }
        public int? author_id { get; set; }
    }
}
