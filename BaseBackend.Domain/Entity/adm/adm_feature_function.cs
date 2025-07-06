namespace BaseBackend.Domain
{
    public class adm_feature_function : BaseEntity
    {
        #region Primitive members

        public const string C_feature_function_id = "feature_function_id"; // 
        private int? _feature_function_id;
        [PropertyEntity(C_feature_function_id, true, true)]
        public int? feature_function_id
        {
            get { return _feature_function_id; }
            set { _feature_function_id = value;}
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

        public const string C_rule_id = "rule_id"; // 
        private int? _rule_id;
        [PropertyEntity(C_rule_id)]
        public int? rule_id
        {
            get { return _rule_id; }
            set { _rule_id = value; NotifyPropertyChanged(C_rule_id); }
        }

        public const string C_url = "url"; // 
        private string _url;
        [PropertyEntity(C_url)]
        public string url
        {
            get { return _url; }
            set { _url = value; NotifyPropertyChanged(C_url); }
        }


        public adm_feature_function() : base("adm_feature_function", "feature_function_id", false, false) { }

        #endregion

        #region Extend members

        #endregion

        #region Clone

        public adm_feature_function CloneToInsert()
        {
            adm_feature_function newItem = new adm_feature_function();

            newItem.feature_function_id = this.feature_function_id;
            newItem.feature_id = this.feature_id;
            newItem.function_id = this.function_id;
            newItem.rule_id = this.rule_id;
            newItem.url = this.url;

            return newItem;
        }

        public adm_feature_function CloneToUpdate()
        {
            adm_feature_function newItem = new adm_feature_function();

            newItem.feature_function_id = this.feature_function_id;
            newItem.feature_id = this.feature_id;
            newItem.function_id = this.function_id;
            newItem.rule_id = this.rule_id;
            newItem.url = this.url;

            return newItem;
        }

        #endregion
    }

}
