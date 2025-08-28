namespace BaseBackend.Domain
{
    public class adm_right : BaseEntity
    {
        #region Primitive members

        public const string C_right_id = "right_id"; // 
        private int? _right_id;
        [PropertyEntity(C_right_id, true, true)]
        public int? right_id
        {
            get { return _right_id; }
            set { _right_id = value;}
        }

        public const string C_role_id = "role_id"; // 
        private int? _role_id;
        [PropertyEntity(C_role_id)]
        public int? role_id
        {
            get { return _role_id; }
            set { _role_id = value; NotifyPropertyChanged(C_role_id); }
        }

        public const string C_feature_id = "feature_id"; // 
        private int? _feature_id;
        [PropertyEntity(C_feature_id)]
        public int? feature_id
        {
            get { return _feature_id; }
            set { _feature_id = value; NotifyPropertyChanged(C_feature_id); }
        }

        public const string C_function_id = "function_id"; // 
        private int? _function_id;
        [PropertyEntity(C_function_id)]
        public int? function_id
        {
            get { return _function_id; }
            set { _function_id = value; NotifyPropertyChanged(C_function_id); }
        }

        public const string C_user_id = "user_id"; // 
        private int? _user_id;
        [PropertyEntity(C_user_id)]
        public int? user_id
        {
            get { return _user_id; }
            set { _user_id = value; NotifyPropertyChanged(C_user_id); }
        }
        public adm_right() : base("adm_right", "right_id", false, false) { }

        #endregion

        #region Extend members

        #endregion

        #region Clone

        public adm_right CloneToInsert()
        {
            adm_right newItem = new adm_right();

            newItem.right_id = this.right_id;
            newItem.role_id = this.role_id;
            newItem.feature_id = this.feature_id;
            newItem.function_id = this.function_id;

            return newItem;
        }

        public adm_right CloneToUpdate()
        {
            adm_right newItem = new adm_right();

            newItem.right_id = this.right_id;
            newItem.role_id = this.role_id;
            newItem.feature_id = this.feature_id;
            newItem.function_id = this.function_id;

            return newItem;
        }

        #endregion
    }

    public class BuildRightConfig
    {
        public int? ItemId { get; set; }
        public string? Name { get; set; }
        public List<int?>? FunctionIds { get; set; }
        public int? RuleId { get; set; }
    }
}
