namespace BaseBackend.Domain.Entity.adm
{
    public class AdmClientAuthenticate : BaseEntity
    {
        #region Primitive members

        public const string C_client_authenticate_id = "client_authenticate_id"; // 
        private int _client_authenticate_id;
        [PropertyEntity(C_client_authenticate_id, true, true)]
        public int client_authenticate_id
        {
            get { return _client_authenticate_id; }
            set
            {
                _client_authenticate_id = value;
            }
        }

        public const string C_request_id = "request_id"; // 
        private int? _request_id;
        [PropertyEntity(C_request_id)]
        public int? request_id
        {
            get { return _request_id; }
            set
            {
                _request_id = value;
            }
        }

        public const string C_public_key = "public_key"; // 
        private string? _public_key;
        [PropertyEntity(C_public_key)]
        public string? public_key
        {
            get { return _public_key; }
            set
            {
                _public_key = value; NotifyPropertyChanged(C_public_key);
            }
        }

        public const string C_private_key = "private_key"; // 
        private string? _private_key;
        [PropertyEntity(C_private_key)]
        public string? private_key
        {
            get { return _private_key; }
            set
            {
                _private_key = value; NotifyPropertyChanged(C_private_key);
            }
        }

        public const string C_requested_dtg = "requested_dtg"; // 
        private DateTime? _requested_dtg;
        [PropertyEntity(C_requested_dtg)]
        public DateTime? requested_dtg
        {
            get { return _requested_dtg; }
            set
            {
                _requested_dtg = value;
            }
        }

        public const string C_expiried_dtg = "expiried_dtg"; // 
        private DateTime? _expiried_dtg;
        [PropertyEntity(C_expiried_dtg)]
        public DateTime? expiried_dtg
        {
            get { return _expiried_dtg; }
            set
            {
                _expiried_dtg = value;
            }
        }

        public const string C_used_dtg = "used_dtg"; // 
        private DateTime? _used_dtg;
        [PropertyEntity(C_used_dtg)]
        public DateTime? used_dtg
        {
            get { return _used_dtg; }
            set
            {
                _used_dtg = value;
            }
        }

        public const string C_requested_by = "requested_by"; // 
        private int? _requested_by;
        [PropertyEntity(C_requested_by)]
        public int? requested_by
        {
            get { return _requested_by; }
            set
            {
                _requested_by = value;
            }
        }

        public const string C_client_ip = "client_ip"; // 
        private string? _client_ip;
        [PropertyEntity(C_client_ip)]
        public string? client_ip
        {
            get { return _client_ip; }
            set
            {
                _client_ip = value; NotifyPropertyChanged(C_client_ip);
            }
        }

        public AdmClientAuthenticate() : base("adm_client_authenticate", "client_authenticate_id", false, false) { }

        #endregion

        #region Extend members
        // add extended properties here

        #endregion

        #region Clone

        public AdmClientAuthenticate CloneToInsert()
        {
            AdmClientAuthenticate newItem = new AdmClientAuthenticate();

            newItem.client_authenticate_id = this.client_authenticate_id;
            newItem.request_id = this.request_id;
            newItem.public_key = this.public_key;
            newItem.private_key = this.private_key;
            newItem.requested_dtg = this.requested_dtg;
            newItem.expiried_dtg = this.expiried_dtg;
            newItem.used_dtg = this.used_dtg;
            newItem.requested_by = this.requested_by;
            newItem.client_ip = this.client_ip;

            return newItem;
        }

        public AdmClientAuthenticate CloneToUpdate()
        {
            AdmClientAuthenticate newItem = new AdmClientAuthenticate();

            newItem.client_authenticate_id = this.client_authenticate_id;
            newItem.request_id = this.request_id;
            newItem.public_key = this.public_key;
            newItem.private_key = this.private_key;
            newItem.requested_dtg = this.requested_dtg;
            newItem.expiried_dtg = this.expiried_dtg;
            newItem.used_dtg = this.used_dtg;
            newItem.requested_by = this.requested_by;
            newItem.client_ip = this.client_ip;

            return newItem;
        }

        #endregion

    }

}
