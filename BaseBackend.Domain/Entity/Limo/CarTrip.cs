namespace BaseBackend.Domain
{
    /// <summary>
    /// Entity cho tuyến đường xe limousine
    /// </summary>
    public class CarTrip : BaseEntity
    {
        #region Primitive members

        public const string C_car_trip_id = "car_trip_id";
        private int? _car_trip_id;
        [PropertyEntity(C_car_trip_id, true, true)]
        public int? car_trip_id
        {
            get { return _car_trip_id; }
            set { _car_trip_id = value; NotifyPropertyChanged(C_car_trip_id); }
        }

        public const string C_departure = "departure";
        private string? _departure;
        [PropertyEntity(C_departure)]
        public string? departure
        {
            get { return _departure; }
            set { _departure = value; NotifyPropertyChanged(C_departure); }
        }

        public const string C_destination = "destination";
        private string? _destination;
        [PropertyEntity(C_destination)]
        public string? destination
        {
            get { return _destination; }
            set { _destination = value; NotifyPropertyChanged(C_destination); }
        }

        public const string C_distance_km = "distance_km";
        private decimal? _distance_km;
        [PropertyEntity(C_distance_km)]
        public decimal? distance_km
        {
            get { return _distance_km; }
            set { _distance_km = value; NotifyPropertyChanged(C_distance_km); }
        }

        public const string C_duration_hours = "duration_hours";
        private decimal? _duration_hours;
        [PropertyEntity(C_duration_hours)]
        public decimal? duration_hours
        {
            get { return _duration_hours; }
            set { _duration_hours = value; NotifyPropertyChanged(C_duration_hours); }
        }

        public const string C_base_price = "base_price";
        private decimal? _base_price;
        [PropertyEntity(C_base_price)]
        public decimal? base_price
        {
            get { return _base_price; }
            set { _base_price = value; NotifyPropertyChanged(C_base_price); }
        }

        public const string C_status = "status";
        private int? _status;
        [PropertyEntity(C_status)]
        public int? status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged(C_status); }
        }

        public const string C_description = "description";
        private string? _description;
        [PropertyEntity(C_description)]
        public string? description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(C_description); }
        }

        public const string C_version = "version";
        private int? _version;
        [PropertyEntity(C_version)]
        public int? version
        {
            get { return _version; }
            set { _version = value; NotifyPropertyChanged(C_version); }
        }

        public const string C_deleted = "deleted";
        private int? _deleted;
        [PropertyEntity(C_deleted)]
        public int? deleted
        {
            get { return _deleted; }
            set { _deleted = value; NotifyPropertyChanged(C_deleted); }
        }

        public const string C_created_time = "created_time";
        private DateTime? _created_time;
        [PropertyEntity(C_created_time)]
        public DateTime? created_time
        {
            get { return _created_time; }
            set { _created_time = value; NotifyPropertyChanged(C_created_time); }
        }

        public const string C_created_by = "created_by";
        private int? _created_by;
        [PropertyEntity(C_created_by)]
        public int? created_by
        {
            get { return _created_by; }
            set { _created_by = value; NotifyPropertyChanged(C_created_by); }
        }

        public const string C_updated_time = "updated_time";
        private DateTime? _updated_time;
        [PropertyEntity(C_updated_time)]
        public DateTime? updated_time
        {
            get { return _updated_time; }
            set { _updated_time = value; NotifyPropertyChanged(C_updated_time); }
        }

        public const string C_updated_by = "updated_by";
        private int? _updated_by;
        [PropertyEntity(C_updated_by)]
        public int? updated_by
        {
            get { return _updated_by; }
            set { _updated_by = value; NotifyPropertyChanged(C_updated_by); }
        }

        public CarTrip() : base("car_trip", "car_trip_id", true, true) { }

        #endregion

        #region Clone

        public CarTrip CloneToInsert()
        {
            CarTrip newItem = new CarTrip();

            newItem.car_trip_id = this.car_trip_id;
            newItem.departure = this.departure;
            newItem.destination = this.destination;
            newItem.distance_km = this.distance_km;
            newItem.duration_hours = this.duration_hours;
            newItem.base_price = this.base_price;
            newItem.status = this.status;
            newItem.description = this.description;
            newItem.version = this.version;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            newItem.created_by = this.created_by;
            newItem.updated_time = this.updated_time;
            newItem.updated_by = this.updated_by;

            return newItem;
        }

        public CarTrip CloneToUpdate()
        {
            CarTrip newItem = new CarTrip();

            newItem.car_trip_id = this.car_trip_id;
            newItem.departure = this.departure;
            newItem.destination = this.destination;
            newItem.distance_km = this.distance_km;
            newItem.duration_hours = this.duration_hours;
            newItem.base_price = this.base_price;
            newItem.status = this.status;
            newItem.description = this.description;

            return newItem;
        }

        #endregion
    }
}
