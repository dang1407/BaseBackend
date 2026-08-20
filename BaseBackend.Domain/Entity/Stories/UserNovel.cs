namespace BaseBackend.Domain.Entity.Stories
{
    public class UserNovel : BaseEntity
    {
        #region Primitive members

        public const string C_user_novel_id = "user_novel_id"; // 
        private int _user_novel_id { get; set; }
        [PropertyEntity(C_user_novel_id, true, true)]
        public int user_novel_id
        {
            get { return _user_novel_id; }
            set
            {
                _user_novel_id = value;
            }
        }

        public const string C_user_id = "user_id"; // 
        private int? _user_id { get; set; }
        [PropertyEntity(C_user_id)]
        public int? user_id
        {
            get { return _user_id; }
            set
            {
                _user_id = value;
            }
        }

        public const string C_novel_id = "novel_id"; // 
        private int? _novel_id { get; set; }
        [PropertyEntity(C_novel_id)]
        public int? novel_id
        {
            get { return _novel_id; }
            set
            {
                _novel_id = value;
            }
        }

        public UserNovel() : base("user_novel", "user_novel_id", false, false) { }

        #endregion

        #region Extend members
        // add extended properties here

        #endregion

        #region Clone

        public UserNovel CloneToInsert()
        {
            UserNovel newItem = new UserNovel();

            newItem.user_novel_id = this.user_novel_id;
            newItem.user_id = this.user_id;
            newItem.novel_id = this.novel_id;

            return newItem;
        }

        public UserNovel CloneToUpdate()
        {
            UserNovel newItem = new UserNovel();

            newItem.user_novel_id = this.user_novel_id;
            newItem.user_id = this.user_id;
            newItem.novel_id = this.novel_id;

            return newItem;
        }

        #endregion

    }

}
