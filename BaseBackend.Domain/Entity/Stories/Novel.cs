using System;

namespace BaseBackend.Domain
{
    public class Novel : BaseEntity
    {
        #region Primitive members

        public const string C_novel_id = "novel_id";
        private int? _novel_id;
        [PropertyEntity(C_novel_id, true, true)]
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

        public const string C_author_id = "author_id";
        private int? _author_id;
        [PropertyEntity(C_author_id)]
        public int? author_id
        {
            get { return _author_id; }
            set { _author_id = value; NotifyPropertyChanged(C_author_id); }
        }

        public const string C_rating = "rating";
        private double _rating;
        [PropertyEntity(C_rating)]
        public double rating
        {
            get { return _rating; }
            set { _rating = value; NotifyPropertyChanged(C_rating); }
        }

        public const string C_chapters_count = "chapters_count";
        private int _chapters_count;
        [PropertyEntity(C_chapters_count)]
        public int chapters_count
        {
            get { return _chapters_count; }
            set { _chapters_count = value; NotifyPropertyChanged(C_chapters_count); }
        }

        public const string C_status = "status";
        private string? _status;
        [PropertyEntity(C_status)]
        public string? status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged(C_status); }
        }

        public const string C_description = "description";
        private string? _description;
        [PropertyEntity(C_description)]
        public string? description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(C_description); }
        }

        public const string C_cover_url = "cover_url";
        private string? _cover_url;
        [PropertyEntity(C_cover_url)]
        public string? cover_url
        {
            get { return _cover_url; }
            set { _cover_url = value; NotifyPropertyChanged(C_cover_url); }
        }

        public const string C_genres = "genres";
        private string? _genres; // Comma separated values or Postgres array
        [PropertyEntity(C_genres)]
        public string? genres
        {
            get { return _genres; }
            set { _genres = value; NotifyPropertyChanged(C_genres); }
        }

        public const string C_subscribers_count = "subscribers_count";
        private int _subscribers_count;
        [PropertyEntity(C_subscribers_count)]
        public int subscribers_count
        {
            get { return _subscribers_count; }
            set { _subscribers_count = value; NotifyPropertyChanged(C_subscribers_count); }
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

        public Novel() : base("novel", "novel_id", true, true) { }

        #endregion

        #region Extends
        public string[]? genres_array { get; set; }
        #endregion

        #region Clone

        public Novel CloneToInsert()
        {
            Novel newItem = new Novel();
            newItem.novel_id = this.novel_id;
            newItem.title = this.title;
            newItem.author_id = this.author_id;
            newItem.rating = this.rating;
            newItem.chapters_count = this.chapters_count;
            newItem.status = this.status;
            newItem.description = this.description;
            newItem.cover_url = this.cover_url;
            newItem.genres = this.genres;
            newItem.subscribers_count = this.subscribers_count;
            newItem.views_count = this.views_count;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            newItem.updated_time = this.updated_time;
            return newItem;
        }

        public Novel CloneToUpdate()
        {
            Novel newItem = new Novel();
            newItem.novel_id = this.novel_id;
            newItem.title = this.title;
            newItem.author_id = this.author_id;
            newItem.rating = this.rating;
            newItem.chapters_count = this.chapters_count;
            newItem.status = this.status;
            newItem.description = this.description;
            newItem.cover_url = this.cover_url;
            newItem.genres = this.genres;
            newItem.subscribers_count = this.subscribers_count;
            newItem.views_count = this.views_count;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            newItem.updated_time = this.updated_time;
            return newItem;
        }

        #endregion
    }
}
