namespace BaseBackend.Domain
{
    public class adm_general_setting : BaseEntity
    {
        #region Primitive members

        public const string C_setting_key = "setting_key"; // 
        private string _setting_key;
        [PropertyEntity(C_setting_key)]
        public string setting_key
        {
            get { return _setting_key; }
            set { _setting_key = value; NotifyPropertyChanged(C_setting_key); }
        }

        public const string C_setting_value = "setting_value"; // 
        private string _setting_value;
        [PropertyEntity(C_setting_value)]
        public string setting_value
        {
            get { return _setting_value; }
            set { _setting_value = value; NotifyPropertyChanged(C_setting_value); }
        }

        public const string C_description = "description"; // 
        private string _description;
        [PropertyEntity(C_description)]
        public string description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(C_description); }
        }


        public adm_general_setting() : base("adm_general_setting", "", false, false) { }

        #endregion

        #region Extend members

        #endregion

        #region Clone

        public adm_general_setting CloneToInsert()
        {
            adm_general_setting newItem = new adm_general_setting();

            newItem.setting_key = this.setting_key;
            newItem.setting_value = this.setting_value;
            newItem.description = this.description;

            return newItem;
        }

        public adm_general_setting CloneToUpdate()
        {
            adm_general_setting newItem = new adm_general_setting();

            newItem.setting_key = this.setting_key;
            newItem.setting_value = this.setting_value;
            newItem.description = this.description;

            return newItem;
        }

        #endregion
    }

}
