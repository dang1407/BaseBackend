namespace BaseBackend.Domain
{
    public partial class adm_user : BaseEntity
    {
        #region Primitive members

        public const string C_user_id = "user_id"; // 
        private int? _user_id;
        [PropertyEntity(C_user_id, true, true)]
        public int? user_id
        {
            get { return _user_id; }
            set { _user_id = value; NotifyPropertyChanged(C_user_id); }
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

        public const string C_username = "username"; // 
        private string? _username;
        [PropertyEntity(C_username)]
        public string? username
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged(C_username); }
        }

        public const string C_password = "password"; // 
        private string? _password;
        [PropertyEntity(C_password)]
        public string? password
        {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged(C_password); }
        }

        public const string C_gender = "gender"; // 
        private int? _gender;
        [PropertyEntity(C_gender)]
        public int? gender
        {
            get { return _gender; }
            set { _gender = value; NotifyPropertyChanged(C_gender); }
        }

        public const string C_dob = "dob"; // 
        private DateTime? _dob;
        [PropertyEntity(C_dob)]
        public DateTime? dob
        {
            get { return _dob; }
            set { _dob = value; NotifyPropertyChanged(C_dob); }
        }

        public const string C_status = "status"; // 
        private int? _status;
        [PropertyEntity(C_status)]
        public int? status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged(C_status); }
        }

        public const string C_email = "email"; // 
        private string? _email;
        [PropertyEntity(C_email)]
        public string? email
        {
            get { return _email; }
            set { _email = value; NotifyPropertyChanged(C_email); }
        }

        public const string C_phone = "phone"; // 
        private string? _phone;
        [PropertyEntity(C_phone)]
        public string? phone
        {
            get { return _phone; }
            set { _phone = value; NotifyPropertyChanged(C_phone); }
        }

        public const string C_number_of_fail = "number_of_fail"; // 
        private int? _number_of_fail;
        [PropertyEntity(C_number_of_fail)]
        public int? number_of_fail
        {
            get { return _number_of_fail; }
            set { _number_of_fail = value; NotifyPropertyChanged(C_number_of_fail); }
        }

        public const string C_is_locked = "is_locked"; // 
        private bool? _is_locked;
        [PropertyEntity(C_is_locked)]
        public bool? is_locked
        {
            get { return _is_locked; }
            set { _is_locked = value; NotifyPropertyChanged(C_is_locked); }
        }

        public const string C_notes = "notes"; // 
        private string? _notes;
        [PropertyEntity(C_notes)]
        public string? notes
        {
            get { return _notes; }
            set { _notes = value; NotifyPropertyChanged(C_notes); }
        }

        public const string C_authencation_type = "authencation_type"; // 
        private int? _authencation_type;
        [PropertyEntity(C_authencation_type)]
        public int? authencation_type
        {
            get { return _authencation_type; }
            set { _authencation_type = value; NotifyPropertyChanged(C_authencation_type); }
        }

        public const string C_password_salt = "password_salt"; // 
        private string? _password_salt;
        [PropertyEntity(C_password_salt)]
        public string? password_salt
        {
            get { return _password_salt; }
            set { _password_salt = value; NotifyPropertyChanged(C_password_salt); }
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


        public adm_user() : base("adm_user", "user_id", true, true) { }

        #endregion

        #region Extend members
        #endregion

        #region Clone

        public adm_user CloneToInsert()
        {
            adm_user newItem = new adm_user();

            newItem.user_id = this.user_id;
            newItem.name = this.name;
            newItem.code = this.code;
            newItem.username = this.username;
            newItem.password = this.password;
            newItem.gender = this.gender;
            newItem.dob = this.dob;
            newItem.status = this.status;
            newItem.email = this.email;
            newItem.phone = this.phone;
            newItem.number_of_fail = this.number_of_fail;
            newItem.is_locked = this.is_locked;
            newItem.notes = this.notes;
            newItem.authencation_type = this.authencation_type;
            newItem.password_salt = this.password_salt;
            newItem.version = this.version;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            newItem.created_by = this.created_by;
            newItem.updated_time = this.updated_time;
            newItem.updated_by = this.updated_by;

            return newItem;
        }

        public adm_user CloneToUpdate()
        {
            adm_user newItem = new adm_user();

            newItem.user_id = this.user_id;
            newItem.name = this.name;
            newItem.code = this.code;
            //newItem.username = this.username;
            //newItem.password = this.password;
            newItem.gender = this.gender;
            newItem.dob = this.dob;
            newItem.status = this.status;
            newItem.email = this.email;
            newItem.phone = this.phone;
            newItem.number_of_fail = this.number_of_fail;
            newItem.is_locked = this.is_locked;
            newItem.notes = this.notes;
            //newItem.authencation_type = this.authencation_type;
            //newItem.password_salt = this.password_salt;
            //newItem.version = this.version;
            //newItem.deleted = this.deleted;
            //newItem.created_time = this.created_time;
            //newItem.created_by = this.created_by;
            //newItem.updated_time = this.updated_time;
            //newItem.updated_by = this.updated_by;

            return newItem;
        }

        #endregion
    }

}
