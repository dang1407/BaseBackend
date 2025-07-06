namespace BaseBackend.Domain
{
    public class adm_userFilter : BaseFilter
    {
        public string? username { get; set; }
        public string? name { get; set; }
        public int? gender { get; set; }
        public DateTime? dob_from { get; set; }
    }
}
