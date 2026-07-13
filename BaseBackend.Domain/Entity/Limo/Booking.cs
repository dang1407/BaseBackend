namespace BaseBackend.Domain
{
    /// <summary>
    /// Entity cho đặt chỗ xe limousine
    /// </summary>
    public class Booking : BaseEntity
    {
        #region Primitive members

        public const string C_booking_id = "booking_id";
        private int? _booking_id;
        [PropertyEntity(C_booking_id, true, true)]
        public int? booking_id
        {
            get { return _booking_id; }
            set { _booking_id = value; NotifyPropertyChanged(C_booking_id); }
        }

        public const string C_car_trip_id = "car_trip_id";
        private int? _car_trip_id;
        [PropertyEntity(C_car_trip_id)]
        public int? car_trip_id
        {
            get { return _car_trip_id; }
            set { _car_trip_id = value; NotifyPropertyChanged(C_car_trip_id); }
        }

        public const string C_customer_name = "customer_name";
        private string? _customer_name;
        [PropertyEntity(C_customer_name)]
        public string? customer_name
        {
            get { return _customer_name; }
            set { _customer_name = value; NotifyPropertyChanged(C_customer_name); }
        }

        public const string C_customer_phone = "customer_phone";
        private string? _customer_phone;
        [PropertyEntity(C_customer_phone)]
        public string? customer_phone
        {
            get { return _customer_phone; }
            set { _customer_phone = value; NotifyPropertyChanged(C_customer_phone); }
        }

        public const string C_departure_date = "departure_date";
        private DateTime? _departure_date;
        [PropertyEntity(C_departure_date)]
        public DateTime? departure_date
        {
            get { return _departure_date; }
            set { _departure_date = value; NotifyPropertyChanged(C_departure_date); }
        }

        public const string C_number_of_passengers = "number_of_passengers";
        private int? _number_of_passengers;
        [PropertyEntity(C_number_of_passengers)]
        public int? number_of_passengers
        {
            get { return _number_of_passengers; }
            set { _number_of_passengers = value; NotifyPropertyChanged(C_number_of_passengers); }
        }

        public const string C_total_price = "total_price";
        private decimal? _total_price;
        [PropertyEntity(C_total_price)]
        public decimal? total_price
        {
            get { return _total_price; }
            set { _total_price = value; NotifyPropertyChanged(C_total_price); }
        }

        public const string C_booking_status = "booking_status";
        private int? _booking_status;
        [PropertyEntity(C_booking_status)]
        public int? booking_status
        {
            get { return _booking_status; }
            set { _booking_status = value; NotifyPropertyChanged(C_booking_status); }
        }

        public const string C_notes = "notes";
        private string? _notes;
        [PropertyEntity(C_notes)]
        public string? notes
        {
            get { return _notes; }
            set { _notes = value; NotifyPropertyChanged(C_notes); }
        }

        public const string C_pickup_location = "pickup_location";
        private string? _pickup_location;
        [PropertyEntity(C_pickup_location)]
        public string? pickup_location
        {
            get { return _pickup_location; }
            set { _pickup_location = value; NotifyPropertyChanged(C_pickup_location); }
        }

        public const string C_dropoff_location = "dropoff_location";
        private string? _dropoff_location;
        [PropertyEntity(C_dropoff_location)]
        public string? dropoff_location
        {
            get { return _dropoff_location; }
            set { _dropoff_location = value; NotifyPropertyChanged(C_dropoff_location); }
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

        public Booking() : base("booking", "booking_id", true, true) { }

        #endregion

        #region Clone

        public Booking CloneToInsert()
        {
            Booking newItem = new Booking();

            newItem.booking_id = this.booking_id;
            newItem.car_trip_id = this.car_trip_id;
            newItem.customer_name = this.customer_name;
            newItem.customer_phone = this.customer_phone;
            newItem.departure_date = this.departure_date;
            newItem.number_of_passengers = this.number_of_passengers;
            newItem.total_price = this.total_price;
            newItem.booking_status = this.booking_status;
            newItem.notes = this.notes;
            newItem.pickup_location = this.pickup_location;
            newItem.dropoff_location = this.dropoff_location;
            newItem.version = this.version;
            newItem.deleted = this.deleted;
            newItem.created_time = this.created_time;
            newItem.created_by = this.created_by;
            newItem.updated_time = this.updated_time;
            newItem.updated_by = this.updated_by;

            return newItem;
        }

        public Booking CloneToUpdate()
        {
            Booking newItem = new Booking();

            newItem.booking_id = this.booking_id;
            newItem.car_trip_id = this.car_trip_id;
            newItem.customer_name = this.customer_name;
            newItem.customer_phone = this.customer_phone;
            newItem.departure_date = this.departure_date;
            newItem.number_of_passengers = this.number_of_passengers;
            newItem.total_price = this.total_price;
            newItem.booking_status = this.booking_status;
            newItem.notes = this.notes;
            newItem.pickup_location = this.pickup_location;
            newItem.dropoff_location = this.dropoff_location;

            return newItem;
        }

        #endregion
    }
}
