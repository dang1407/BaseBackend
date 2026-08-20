using System;

namespace BaseBackend.Domain
{
    public class Comment : BaseEntity
    {
        #region Primitive members

        public const string C_comment_id = "comment_id";
        private int? _comment_id;
        [PropertyEntity(C_comment_id, true, true)]
        public int? comment_id
        {
            get { return _comment_id; }
            set { _comment_id = value; NotifyPropertyChanged(C_comment_id); }
        }

        public const string C_novel_id = "novel_id";
        private int? _novel_id;
        [PropertyEntity(C_novel_id)]
        public int? novel_id
        {
            get { return _novel_id; }
            set { _novel_id = value; NotifyPropertyChanged(C_novel_id); }
        }

        public const string C_chapter_id = "chapter_id";
        private int? _chapter_id;
        [PropertyEntity(C_chapter_id)]
        public int? chapter_id
        {
            get { return _chapter_id; }
            set { _chapter_id = value; NotifyPropertyChanged(C_chapter_id); }
        }

        public const string C_user_id = "user_id";
        private int? _user_id;
        [PropertyEntity(C_user_id)]
        public int? user_id
        {
            get { return _user_id; }
            set { _user_id = value; NotifyPropertyChanged(C_user_id); }
        }

        public const string C_content = "content";
        private string? _content;
        [PropertyEntity(C_content)]
        public string? content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(C_content); }
        }

        public const string C_likes_count = "likes_count";
        private int _likes_count;
        [PropertyEntity(C_likes_count)]
        public int likes_count
        {
            get { return _likes_count; }
            set { _likes_count = value; NotifyPropertyChanged(C_likes_count); }
        }

        public const string C_replies_count = "replies_count";
        private int _replies_count;
        [PropertyEntity(C_replies_count)]
        public int replies_count
        {
            get { return _replies_count; }
            set { _replies_count = value; NotifyPropertyChanged(C_replies_count); }
        }

        public const string C_deleted = "deleted";
        private int? _deleted;
        [PropertyEntity(C_deleted)]
        public int? deleted
        {
            get { return _deleted; }
            set { _deleted = value; NotifyPropertyChanged(C_deleted); }
        }

        public const string C_created_time = "created_time";
        private DateTime? _created_time;
        [PropertyEntity(C_created_time)]
        public DateTime? created_time
        {
            get { return _created_time; }
            set { _created_time = value; NotifyPropertyChanged(C_created_time); }
        }

        public Comment() : base("comment", "comment_id", true, true) { }

        #endregion

        #region Clone

        public Comment CloneToInsert()
        {
            Comment newItem = new Comment();
            newItem.comment_id = this.comment_id;
            newItem.novel_id = this.novel_id;
            newItem.chapter_id = this.chapter_id;
            newItem.user_id = this.user_id;
            newItem.content = this.content;
            newItem.likes_count = this.likes_count;
            newItem.replies_count = this.replies_count;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            return newItem;
        }

        public Comment CloneToUpdate()
        {
            Comment newItem = new Comment();
            newItem.comment_id = this.comment_id;
            newItem.novel_id = this.novel_id;
            newItem.chapter_id = this.chapter_id;
            newItem.user_id = this.user_id;
            newItem.content = this.content;
            newItem.likes_count = this.likes_count;
            newItem.replies_count = this.replies_count;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            return newItem;
        }

        #endregion
    }
}
