using System;

namespace BaseBackend.Domain
{
    public class Chapter : BaseEntity
    {
        #region Primitive members

        public const string C_chapter_id = "chapter_id";
        private int? _chapter_id;
        [PropertyEntity(C_chapter_id, true, true)]
        public int? chapter_id
        {
            get { return _chapter_id; }
            set { _chapter_id = value; NotifyPropertyChanged(C_chapter_id); }
        }

        public const string C_novel_id = "novel_id";
        private int? _novel_id;
        [PropertyEntity(C_novel_id)]
        public int? novel_id
        {
            get { return _novel_id; }
            set { _novel_id = value; NotifyPropertyChanged(C_novel_id); }
        }

        public const string C_title = "title";
        private string? _title;
        [PropertyEntity(C_title)]
        public string? title
        {
            get { return _title; }
            set { _title = value; NotifyPropertyChanged(C_title); }
        }

        public const string C_content = "content";
        private string? _content;
        [PropertyEntity(C_content)]
        public string? content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(C_content); }
        }

        public const string C_views_count = "views_count";
        private int _views_count;
        [PropertyEntity(C_views_count)]
        public int views_count
        {
            get { return _views_count; }
            set { _views_count = value; NotifyPropertyChanged(C_views_count); }
        }

        public const string C_deleted = "deleted";
        private int? _deleted;
        [PropertyEntity(C_deleted)]
        public int? deleted
        {
            get { return _deleted; }
            set { _deleted = value; NotifyPropertyChanged(C_deleted); }
        }

        public const string C_version = "version";
        private int? _version;
        [PropertyEntity(C_version)]
        public int? version
        {
            get { return _version; }
            set { _version = value; NotifyPropertyChanged(C_version); }
        }

        public const string C_created_time = "created_time";
        private DateTime? _created_time;
        [PropertyEntity(C_created_time)]
        public DateTime? created_time
        {
            get { return _created_time; }
            set { _created_time = value; NotifyPropertyChanged(C_created_time); }
        }

        public const string C_created_by = "created_by";
        private int? _created_by;
        [PropertyEntity(C_created_by)]
        public int? created_by
        {
            get { return _created_by; }
            set { _created_by = value; NotifyPropertyChanged(C_created_by); }
        }


        public const string C_updated_time = "updated_time";
        private DateTime? _updated_time;
        [PropertyEntity(C_updated_time)]
        public DateTime? updated_time
        {
            get { return _updated_time; }
            set { _updated_time = value; NotifyPropertyChanged(C_updated_time); }
        }

        public const string C_updated_by = "updated_by";
        private int? _updated_by;
        [PropertyEntity(C_updated_by)]
        public int? updated_by
        {
            get { return _updated_by; }
            set { _updated_by = value; NotifyPropertyChanged(C_updated_by); }
        }

        public Chapter() : base("chapter", "chapter_id", true, true) { }

        #endregion

        #region Clone

        public Chapter CloneToInsert()
        {
            Chapter newItem = new Chapter();
            newItem.chapter_id = this.chapter_id;
            newItem.novel_id = this.novel_id;
            newItem.title = this.title;
            newItem.content = this.content;
            newItem.views_count = this.views_count;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            return newItem;
        }

        public Chapter CloneToUpdate()
        {
            Chapter newItem = new Chapter();
            newItem.chapter_id = this.chapter_id;
            newItem.novel_id = this.novel_id;
            newItem.title = this.title;
            newItem.content = this.content;
            newItem.views_count = this.views_count;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            return newItem;
        }

        #endregion
    }
}
