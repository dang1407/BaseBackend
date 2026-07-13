namespace BaseBackend.Domain
{
    public class CarRoute : BaseEntity
    {
        #region Primitive members

        public const string C_car_route_id = "car_route_id"; // 
        private int _car_route_id { get; set; }
        [PropertyEntity(C_car_route_id, true, true)]
        public int car_route_id
        {
            get { return _car_route_id; }
            set
            {
                _car_route_id = value;
            }
        }

        public const string C_from = "from"; // 
        private string? _from { get; set; }
        [PropertyEntity(C_from)]
        public string? from
        {
            get { return _from; }
            set
            {
                _from = value; NotifyPropertyChanged(C_from);
            }
        }

        public const string C_to = "to"; // 
        private string? _to { get; set; }
        [PropertyEntity(C_to)]
        public string? to
        {
            get { return _to; }
            set
            {
                _to = value; NotifyPropertyChanged(C_to);
            }
        }

        public const string C_price = "price"; // 
        private decimal? _price { get; set; }
        [PropertyEntity(C_price)]
        public decimal? price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }

        public const string C_duration = "duration"; // 
        private string? _duration { get; set; }
        [PropertyEntity(C_duration)]
        public string? duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
            }
        }

        public const string C_status = "status"; // 
        private int? _status { get; set; }
        [PropertyEntity(C_status)]
        public int? status
        {
            get { return _status; }
            set
            {
                _status = value;
            }
        }

        public const string C_version = "version"; // 
        private int? _version { get; set; }
        [PropertyEntity(C_version)]
        public int? version
        {
            get { return _version; }
            set
            {
                _version = value;
            }
        }

        public const string C_deleted = "deleted"; // 
        private int? _deleted { get; set; }
        [PropertyEntity(C_deleted)]
        public int? deleted
        {
            get { return _deleted; }
            set
            {
                _deleted = value;
            }
        }

        public const string C_created_time = "created_time"; // 
        private DateTime? _created_time { get; set; }
        [PropertyEntity(C_created_time)]
        public DateTime? created_time
        {
            get { return _created_time; }
            set
            {
                _created_time = value;
            }
        }

        public const string C_created_by = "created_by"; // 
        private string? _created_by { get; set; }
        [PropertyEntity(C_created_by)]
        public string? created_by
        {
            get { return _created_by; }
            set
            {
                _created_by = value; NotifyPropertyChanged(C_created_by);
            }
        }

        public const string C_updated_time = "updated_time"; // 
        private DateTime? _updated_time { get; set; }
        [PropertyEntity(C_updated_time)]
        public DateTime? updated_time
        {
            get { return _updated_time; }
            set
            {
                _updated_time = value;
            }
        }

        public const string C_updated_by = "updated_by"; // 
        private string? _updated_by { get; set; }
        [PropertyEntity(C_updated_by)]
        public string? updated_by
        {
            get { return _updated_by; }
            set
            {
                _updated_by = value; NotifyPropertyChanged(C_updated_by);
            }
        }

        public CarRoute() : base("car_route", "car_route_id", false, false) { }

        #endregion

        #region Extend members
        // add extended properties here

        #endregion

        #region Clone

        public CarRoute CloneToInsert()
        {
            CarRoute newItem = new CarRoute();

            newItem.car_route_id = this.car_route_id;
            newItem.from = this.from;
            newItem.to = this.to;
            newItem.price = this.price;
            newItem.duration = this.duration;
            newItem.version = this.version;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            newItem.created_by = this.created_by;
            newItem.updated_time = this.updated_time;
            newItem.updated_by = this.updated_by;

            return newItem;
        }

        public CarRoute CloneToUpdate()
        {
            CarRoute newItem = new CarRoute();

            newItem.car_route_id = this.car_route_id;
            newItem.from = this.from;
            newItem.to = this.to;
            newItem.price = this.price;
            newItem.duration = this.duration;
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
