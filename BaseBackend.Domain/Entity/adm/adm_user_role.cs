namespace BaseBackend.Domain.Entity.adm
{
    public class adm_user_role : BaseEntity
    {
        #region Primitive members

        public const string C_user_role_id = "user_role_id"; // 
        private int? _user_role_id;
        [PropertyEntity(C_user_role_id, true, true)]
        public int? user_role_id
        {
            get { return _user_role_id; }
            set { _user_role_id = value; NotifyPropertyChanged(C_user_role_id); }
        }

        public const string C_user_id = "user_id"; // 
        private int? _user_id;
        [PropertyEntity(C_user_id)]
        public int? user_id
        {
            get { return _user_id; }
            set { _user_id = value; NotifyPropertyChanged(C_user_id); }
        }

        public const string C_role_id = "role_id"; // 
        private int? _role_id;
        [PropertyEntity(C_role_id)]
        public int? role_id
        {
            get { return _role_id; }
            set { _role_id = value; NotifyPropertyChanged(C_role_id); }
        }


        public adm_user_role() : base("adm_user_role", "user_role_id", false, false) { }

        #endregion

        #region Extend members

        #endregion

        #region Clone

        public adm_user_role CloneToInsert()
        {
            adm_user_role newItem = new adm_user_role();

            newItem.user_role_id = this.user_role_id;
            newItem.user_id = this.user_id;
            newItem.role_id = this.role_id;

            return newItem;
        }

        public adm_user_role CloneToUpdate()
        {
            adm_user_role newItem = new adm_user_role();

            newItem.user_role_id = this.user_role_id;
            newItem.user_id = this.user_id;
            newItem.role_id = this.role_id;

            return newItem;
        }

        #endregion
    }

}
