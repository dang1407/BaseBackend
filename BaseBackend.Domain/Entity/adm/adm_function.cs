namespace BaseBackend.Domain
{
    public class adm_function : BaseEntity
    {
        #region Primitive members

        public const string C_function_id = "function_id"; // 
        private int? _function_id;
        [PropertyEntity(C_function_id, true, true)]
        public int? function_id
        {
            get { return _function_id; }
            set { _function_id = value; }
        }

        public const string C_code = "code"; // 
        private string? _code;
        [PropertyEntity(C_code)]
        public string? code
        {
            get { return _code; }
            set { _code = value; NotifyPropertyChanged(C_code); }
        }

        public const string C_name = "name"; // 
        private string? _name;
        [PropertyEntity(C_name)]
        public string? name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(C_name); }
        }


        public adm_function() : base("adm_function", "function_id", false, false) { }

        #endregion

        #region Extend members
        public int? feature_function_rule_id { get; set; }
        #endregion

        #region Clone

        public adm_function CloneToInsert()
        {
            adm_function newItem = new adm_function();

            newItem.function_id = this.function_id;
            newItem.code = this.code;
            newItem.name = this.name;

            return newItem;
        }

        public adm_function CloneToUpdate()
        {
            adm_function newItem = new adm_function();

            newItem.function_id = this.function_id;
            newItem.code = this.code;
            newItem.name = this.name;

            return newItem;
        }

        #endregion
    }

}
