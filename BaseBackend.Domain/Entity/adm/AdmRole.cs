namespace BaseBackend.Domain
{
    public class AdmRole : BaseEntity
    {
        #region Primitive members

        public const string C_role_id = "role_id"; // 
        private int? _role_id;
        [PropertyEntity(C_role_id, true, true)]
        public int? role_id
        {
            get { return _role_id; }
            set { _role_id = value; NotifyPropertyChanged(C_role_id); }
        }

        public const string C_name = "name"; // 
        private string? _name;
        [PropertyEntity(C_name)]
        public string? name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(C_name); }
        }

        public const string C_code = "code"; // 
        private string? _code;
        [PropertyEntity(C_code)]
        public string? code
        {
            get { return _code; }
            set { _code = value; NotifyPropertyChanged(C_code); }
        }

        public const string C_description = "description"; // 
        private string? _description;
        [PropertyEntity(C_description)]
        public string? description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(C_description); }
        }

        public const string C_is_public = "is_public"; // 
        private bool _is_public;
        [PropertyEntity(C_is_public)]
        public bool is_public
        {
            get { return _is_public; }
            set { _is_public = value; NotifyPropertyChanged(C_is_public); }
        }

        public const string C_is_system = "is_system"; // 
        private bool _is_system;
        [PropertyEntity(C_is_system)]
        public bool is_system
        {
            get { return _is_system; }
            set { _is_system = value; NotifyPropertyChanged(C_is_system); }
        }

        public const string C_is_active = "is_active"; // 
        private bool _is_active;
        [PropertyEntity(C_is_active)]
        public bool is_active
        {
            get { return _is_active; }
            set { _is_active = value; NotifyPropertyChanged(C_is_active); }
        }

        public const string C_fixed_right_codes = "fixed_right_codes"; // 
        private string? _fixed_right_codes;
        [PropertyEntity(C_fixed_right_codes)]
        public string? fixed_right_codes
        {
            get { return _fixed_right_codes; }
            set { _fixed_right_codes = value; NotifyPropertyChanged(C_fixed_right_codes); }
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


        public AdmRole() : base("adm_role", "role_id", true, true) { }

        #endregion

        #region Extend members

        #endregion

        #region Clone

        public AdmRole CloneToInsert()
        {
            AdmRole newItem = new AdmRole();

            newItem.role_id = this.role_id;
            newItem.name = this.name;
            newItem.code = this.code;
            newItem.description = this.description;
            newItem.is_public = this.is_public;
            newItem.is_system = this.is_system;
            newItem.is_active = this.is_active;
            newItem.fixed_right_codes = this.fixed_right_codes;
            newItem.version = this.version;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            newItem.created_by = this.created_by;
            newItem.updated_time = this.updated_time;
            newItem.updated_by = this.updated_by;

            return newItem;
        }

        public AdmRole CloneToUpdate()
        {
            AdmRole newItem = new AdmRole();

            newItem.role_id = this.role_id;
            newItem.name = this.name;
            newItem.code = this.code;
            newItem.description = this.description;
            newItem.is_public = this.is_public;
            newItem.is_system = this.is_system;
            newItem.is_active = this.is_active;
            newItem.fixed_right_codes = this.fixed_right_codes;
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
