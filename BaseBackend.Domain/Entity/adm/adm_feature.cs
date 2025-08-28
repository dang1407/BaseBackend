namespace BaseBackend.Domain
{
    public class adm_feature : BaseEntity
    {
        #region Primitive members

        public const string C_feature_id = "feature_id"; // 
        private int? _feature_id;
        [PropertyEntity(C_feature_id, true, true)]
        public int? feature_id
        {
            get { return _feature_id; }
            set { _feature_id = value;}
        }

        public const string C_name = "name"; // 
        private string? _name;
        [PropertyEntity(C_name)]
        public string? name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(C_name); }
        }

        public const string C_parent_id = "parent_id"; // 
        private int? _parent_id;
        [PropertyEntity(C_parent_id)]
        public int? parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; NotifyPropertyChanged(C_parent_id); }
        }

        public const string C_status = "status"; // 
        private int? _status;
        [PropertyEntity(C_status)]
        public int? status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged(C_status); }
        }

        public const string C_description = "description"; // 
        private string? _description;
        [PropertyEntity(C_description)]
        public string? description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(C_description); }
        }

        public const string C_url = "url"; // 
        private string? _url;
        [PropertyEntity(C_url)]
        public string? url
        {
            get { return _url; }
            set { _url = value; NotifyPropertyChanged(C_url); }
        }

        public const string C_is_visible = "is_visible"; // 
        private int? _is_visible;
        [PropertyEntity(C_is_visible)]
        public int? is_visible
        {
            get { return _is_visible; }
            set { _is_visible = value; NotifyPropertyChanged(C_is_visible); }
        }

        public const string C_display_order = "display_order"; // 
        private int? _display_order;
        [PropertyEntity(C_display_order)]
        public int? display_order
        {
            get { return _display_order; }
            set { _display_order = value; NotifyPropertyChanged(C_display_order); }
        }

        public const string C_icon = "icon"; // 
        private string? _icon;
        [PropertyEntity(C_icon)]
        public string? icon
        {
            get { return _icon; }
            set { _icon = value; NotifyPropertyChanged(C_icon); }
        }

        public const string C_version = "version"; // 
        private int? _version;
        [PropertyEntity(C_version)]
        public int? version
        {
            get { return _version; }
            set { _version = value; NotifyPropertyChanged(C_version); }
        }

        public const string C_deleted = "deleted"; // 
        private int? _deleted;
        [PropertyEntity(C_deleted)]
        public int? deleted
        {
            get { return _deleted; }
            set { _deleted = value; NotifyPropertyChanged(C_deleted); }
        }

        public const string C_created_time = "created_time"; // 
        private DateTime? _created_time;
        [PropertyEntity(C_created_time)]
        public DateTime? created_time
        {
            get { return _created_time; }
            set { _created_time = value; NotifyPropertyChanged(C_created_time); }
        }

        public const string C_created_by = "created_by"; // 
        private int? _created_by;
        [PropertyEntity(C_created_by)]
        public int? created_by
        {
            get { return _created_by; }
            set { _created_by = value; NotifyPropertyChanged(C_created_by); }
        }

        public const string C_updated_time = "updated_time"; // 
        private DateTime? _updated_time;
        [PropertyEntity(C_updated_time)]
        public DateTime? updated_time
        {
            get { return _updated_time; }
            set { _updated_time = value; NotifyPropertyChanged(C_updated_time); }
        }

        public const string C_updated_by = "updated_by"; // 
        private int? _updated_by;
        [PropertyEntity(C_updated_by)]
        public int? updated_by
        {
            get { return _updated_by; }
            set { _updated_by = value; NotifyPropertyChanged(C_updated_by); }
        }


        public adm_feature() : base("adm_feature", "feature_id", true, true) { }

        #endregion

        #region Extend members

        #endregion

        #region Clone

        public adm_feature CloneToInsert()
        {
            adm_feature newItem = new adm_feature();

            newItem.feature_id = this.feature_id;
            newItem.name = this.name;
            newItem.parent_id = this.parent_id;
            newItem.status = this.status;
            newItem.description = this.description;
            newItem.url = this.url;
            newItem.is_visible = this.is_visible;
            newItem.display_order = this.display_order;
            newItem.icon = this.icon;
            newItem.version = this.version;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            newItem.created_by = this.created_by;
            newItem.updated_time = this.updated_time;
            newItem.updated_by = this.updated_by;

            return newItem;
        }

        public adm_feature CloneToUpdate()
        {
            adm_feature newItem = new adm_feature();

            newItem.feature_id = this.feature_id;
            newItem.name = this.name;
            newItem.parent_id = this.parent_id;
            newItem.status = this.status;
            newItem.description = this.description;
            newItem.url = this.url;
            newItem.is_visible = this.is_visible;
            newItem.display_order = this.display_order;
            newItem.icon = this.icon;
            newItem.version = this.version;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            newItem.created_by = this.created_by;
            newItem.updated_time = this.updated_time;
            newItem.updated_by = this.updated_by;

            return newItem;
        }

        #endregion
    }

}
