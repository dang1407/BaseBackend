using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain.Entity
{
    public class sav_ArrangementRequestChangeOld : BaseEntity
    {
        #region Primitive members

        public const string C_ARRANGEMENT_REQUEST_CHANGE_OLD_ID = "ARRANGEMENT_REQUEST_CHANGE_OLD_ID"; // 
        private int? _ARRANGEMENT_REQUEST_CHANGE_OLD_ID;
        [PropertyEntity(C_ARRANGEMENT_REQUEST_CHANGE_OLD_ID, true)]
        public int? ARRANGEMENT_REQUEST_CHANGE_OLD_ID
        {
            get { return _ARRANGEMENT_REQUEST_CHANGE_OLD_ID; }
            set { _ARRANGEMENT_REQUEST_CHANGE_OLD_ID = value; }
        }

        public const string C_ARRANGEMENT_REQUEST_CHANGE_ID = "ARRANGEMENT_REQUEST_CHANGE_ID"; // 
        private int? _ARRANGEMENT_REQUEST_CHANGE_ID;
        [PropertyEntity(C_ARRANGEMENT_REQUEST_CHANGE_ID, false)]
        public int? ARRANGEMENT_REQUEST_CHANGE_ID
        {
            get { return _ARRANGEMENT_REQUEST_CHANGE_ID; }
            set { _ARRANGEMENT_REQUEST_CHANGE_ID = value; }
        }

        public const string C_ARRANGEMENT_ID = "ARRANGEMENT_ID"; // 
        private int? _ARRANGEMENT_ID;
        [PropertyEntity(C_ARRANGEMENT_ID, false)]
        public int? ARRANGEMENT_ID
        {
            get { return _ARRANGEMENT_ID; }
            set { _ARRANGEMENT_ID = value; }
        }

        public const string C_PRODUCT_ID = "PRODUCT_ID"; // 
        private int? _PRODUCT_ID;
        [PropertyEntity(C_PRODUCT_ID, false)]
        public int? PRODUCT_ID
        {
            get { return _PRODUCT_ID; }
            set { _PRODUCT_ID = value; }
        }

        public const string C_CUSTOMER_CODE = "CUSTOMER_CODE"; // 
        private string _CUSTOMER_CODE;
        [PropertyEntity(C_CUSTOMER_CODE, false)]
        public string CUSTOMER_CODE
        {
            get { return _CUSTOMER_CODE; }
            set { _CUSTOMER_CODE = value; }
        }

        public const string C_CUSTOMER_NAME = "CUSTOMER_NAME"; // 
        private string _CUSTOMER_NAME;
        [PropertyEntity(C_CUSTOMER_NAME, false)]
        public string CUSTOMER_NAME
        {
            get { return _CUSTOMER_NAME; }
            set { _CUSTOMER_NAME = value; }
        }

        public const string C_CUSTOMER_TYPE = "CUSTOMER_TYPE"; // 
        private int? _CUSTOMER_TYPE;
        [PropertyEntity(C_CUSTOMER_TYPE, false)]
        public int? CUSTOMER_TYPE
        {
            get { return _CUSTOMER_TYPE; }
            set { _CUSTOMER_TYPE = value; }
        }

        public const string C_CUSTOMER_RANK = "CUSTOMER_RANK"; // 
        private int? _CUSTOMER_RANK;
        [PropertyEntity(C_CUSTOMER_RANK, false)]
        public int? CUSTOMER_RANK
        {
            get { return _CUSTOMER_RANK; }
            set { _CUSTOMER_RANK = value; }
        }

        public const string C_CUSTOMER_IDENTIFICATION_TYPE = "CUSTOMER_IDENTIFICATION_TYPE"; // 
        private int? _CUSTOMER_IDENTIFICATION_TYPE;
        [PropertyEntity(C_CUSTOMER_IDENTIFICATION_TYPE, false)]
        public int? CUSTOMER_IDENTIFICATION_TYPE
        {
            get { return _CUSTOMER_IDENTIFICATION_TYPE; }
            set { _CUSTOMER_IDENTIFICATION_TYPE = value; }
        }

        public const string C_CUSTOMER_IDENTIFICATION_NO = "CUSTOMER_IDENTIFICATION_NO"; // 
        private string _CUSTOMER_IDENTIFICATION_NO;
        [PropertyEntity(C_CUSTOMER_IDENTIFICATION_NO, false)]
        public string CUSTOMER_IDENTIFICATION_NO
        {
            get { return _CUSTOMER_IDENTIFICATION_NO; }
            set { _CUSTOMER_IDENTIFICATION_NO = value; }
        }

        public const string C_CUSTOMER_IDENTIFICATION_DATE = "CUSTOMER_IDENTIFICATION_DATE"; // 
        private DateTime? _CUSTOMER_IDENTIFICATION_DATE;
        [PropertyEntity(C_CUSTOMER_IDENTIFICATION_DATE, false)]
        public DateTime? CUSTOMER_IDENTIFICATION_DATE
        {
            get { return _CUSTOMER_IDENTIFICATION_DATE; }
            set { _CUSTOMER_IDENTIFICATION_DATE = value; }
        }

        public const string C_CUSTOMER_IDENTIFICATION_PLACE = "CUSTOMER_IDENTIFICATION_PLACE"; // 
        private string _CUSTOMER_IDENTIFICATION_PLACE;
        [PropertyEntity(C_CUSTOMER_IDENTIFICATION_PLACE, false)]
        public string CUSTOMER_IDENTIFICATION_PLACE
        {
            get { return _CUSTOMER_IDENTIFICATION_PLACE; }
            set { _CUSTOMER_IDENTIFICATION_PLACE = value; }
        }

        public const string C_CUSTOMER_NATIONALITY_ID = "CUSTOMER_NATIONALITY_ID"; // 
        private int? _CUSTOMER_NATIONALITY_ID;
        [PropertyEntity(C_CUSTOMER_NATIONALITY_ID, false)]
        public int? CUSTOMER_NATIONALITY_ID
        {
            get { return _CUSTOMER_NATIONALITY_ID; }
            set { _CUSTOMER_NATIONALITY_ID = value; }
        }

        public const string C_CUSTOMER_BIRTH_DATE = "CUSTOMER_BIRTH_DATE"; // 
        private DateTime? _CUSTOMER_BIRTH_DATE;
        [PropertyEntity(C_CUSTOMER_BIRTH_DATE, false)]
        public DateTime? CUSTOMER_BIRTH_DATE
        {
            get { return _CUSTOMER_BIRTH_DATE; }
            set { _CUSTOMER_BIRTH_DATE = value; }
        }

        public const string C_CUSTOMER_GENDER = "CUSTOMER_GENDER"; // 
        private int? _CUSTOMER_GENDER;
        [PropertyEntity(C_CUSTOMER_GENDER, false)]
        public int? CUSTOMER_GENDER
        {
            get { return _CUSTOMER_GENDER; }
            set { _CUSTOMER_GENDER = value; }
        }

        public const string C_CUSTOMER_PHONE = "CUSTOMER_PHONE"; // 
        private string _CUSTOMER_PHONE;
        [PropertyEntity(C_CUSTOMER_PHONE, false)]
        public string CUSTOMER_PHONE
        {
            get { return _CUSTOMER_PHONE; }
            set { _CUSTOMER_PHONE = value; }
        }

        public const string C_CUSTOMER_ADDRESS = "CUSTOMER_ADDRESS"; // 
        private string _CUSTOMER_ADDRESS;
        [PropertyEntity(C_CUSTOMER_ADDRESS, false)]
        public string CUSTOMER_ADDRESS
        {
            get { return _CUSTOMER_ADDRESS; }
            set { _CUSTOMER_ADDRESS = value; }
        }

        public const string C_CUSTOMER_RESIDENT_FROM_DATE = "CUSTOMER_RESIDENT_FROM_DATE"; // 
        private DateTime? _CUSTOMER_RESIDENT_FROM_DATE;
        [PropertyEntity(C_CUSTOMER_RESIDENT_FROM_DATE, false)]
        public DateTime? CUSTOMER_RESIDENT_FROM_DATE
        {
            get { return _CUSTOMER_RESIDENT_FROM_DATE; }
            set { _CUSTOMER_RESIDENT_FROM_DATE = value; }
        }

        public const string C_CUSTOMER_RESIDENT_TO_DATE = "CUSTOMER_RESIDENT_TO_DATE"; // 
        private DateTime? _CUSTOMER_RESIDENT_TO_DATE;
        [PropertyEntity(C_CUSTOMER_RESIDENT_TO_DATE, false)]
        public DateTime? CUSTOMER_RESIDENT_TO_DATE
        {
            get { return _CUSTOMER_RESIDENT_TO_DATE; }
            set { _CUSTOMER_RESIDENT_TO_DATE = value; }
        }

        public const string C_SERIAL_NUMBER = "SERIAL_NUMBER"; // 
        private string _SERIAL_NUMBER;
        [PropertyEntity(C_SERIAL_NUMBER, false)]
        public string SERIAL_NUMBER
        {
            get { return _SERIAL_NUMBER; }
            set { _SERIAL_NUMBER = value; }
        }

        public const string C_AA_DEPOSIT_ID = "AA_DEPOSIT_ID"; // 
        private string _AA_DEPOSIT_ID;
        [PropertyEntity(C_AA_DEPOSIT_ID, false)]
        public string AA_DEPOSIT_ID
        {
            get { return _AA_DEPOSIT_ID; }
            set { _AA_DEPOSIT_ID = value; }
        }

        public const string C_AA_ACCOUNT = "AA_ACCOUNT"; // 
        private string _AA_ACCOUNT;
        [PropertyEntity(C_AA_ACCOUNT, false)]
        public string AA_ACCOUNT
        {
            get { return _AA_ACCOUNT; }
            set { _AA_ACCOUNT = value; }
        }

        public const string C_AA_LIVE = "AA_LIVE"; // 
        private string _AA_LIVE;
        [PropertyEntity(C_AA_LIVE, false)]
        public string AA_LIVE
        {
            get { return _AA_LIVE; }
            set { _AA_LIVE = value; }
        }

        public const string C_PRINTED_OWNER_NAME = "PRINTED_OWNER_NAME"; // 
        private string _PRINTED_OWNER_NAME;
        [PropertyEntity(C_PRINTED_OWNER_NAME, false)]
        public string PRINTED_OWNER_NAME
        {
            get { return _PRINTED_OWNER_NAME; }
            set { _PRINTED_OWNER_NAME = value; }
        }

        public const string C_CURRENCY_ID = "CURRENCY_ID"; // 
        private int? _CURRENCY_ID;
        [PropertyEntity(C_CURRENCY_ID, false)]
        public int? CURRENCY_ID
        {
            get { return _CURRENCY_ID; }
            set { _CURRENCY_ID = value; }
        }

        public const string C_PAYIN_AMOUNT = "PAYIN_AMOUNT"; // 
        private decimal? _PAYIN_AMOUNT;
        [PropertyEntity(C_PAYIN_AMOUNT, false)]
        public decimal? PAYIN_AMOUNT
        {
            get { return _PAYIN_AMOUNT; }
            set { _PAYIN_AMOUNT = value; }
        }

        public const string C_ACCURAL_AMOUNT = "ACCURAL_AMOUNT"; // 
        private decimal? _ACCURAL_AMOUNT;
        [PropertyEntity(C_ACCURAL_AMOUNT, false)]
        public decimal? ACCURAL_AMOUNT
        {
            get { return _ACCURAL_AMOUNT; }
            set { _ACCURAL_AMOUNT = value; }
        }

        public const string C_ESTIMATED_INTEREST_AMOUNT = "ESTIMATED_INTEREST_AMOUNT"; // 
        private decimal? _ESTIMATED_INTEREST_AMOUNT;
        [PropertyEntity(C_ESTIMATED_INTEREST_AMOUNT, false)]
        public decimal? ESTIMATED_INTEREST_AMOUNT
        {
            get { return _ESTIMATED_INTEREST_AMOUNT; }
            set { _ESTIMATED_INTEREST_AMOUNT = value; }
        }

        public const string C_ROLLOVER_METHOD = "ROLLOVER_METHOD"; // 
        private int? _ROLLOVER_METHOD;
        [PropertyEntity(C_ROLLOVER_METHOD, false)]
        public int? ROLLOVER_METHOD
        {
            get { return _ROLLOVER_METHOD; }
            set { _ROLLOVER_METHOD = value; }
        }

        public const string C_INTEREST_PAYMENT_METHOD = "INTEREST_PAYMENT_METHOD"; // 
        private int? _INTEREST_PAYMENT_METHOD;
        [PropertyEntity(C_INTEREST_PAYMENT_METHOD, false)]
        public int? INTEREST_PAYMENT_METHOD
        {
            get { return _INTEREST_PAYMENT_METHOD; }
            set { _INTEREST_PAYMENT_METHOD = value; }
        }

        public const string C_INTEREST_PAYMENT_TERM = "INTEREST_PAYMENT_TERM"; // 
        private int? _INTEREST_PAYMENT_TERM;
        [PropertyEntity(C_INTEREST_PAYMENT_TERM, false)]
        public int? INTEREST_PAYMENT_TERM
        {
            get { return _INTEREST_PAYMENT_TERM; }
            set { _INTEREST_PAYMENT_TERM = value; }
        }

        public const string C_ROLLOVER_PERIOD = "ROLLOVER_PERIOD"; // 
        private int? _ROLLOVER_PERIOD;
        [PropertyEntity(C_ROLLOVER_PERIOD, false)]
        public int? ROLLOVER_PERIOD
        {
            get { return _ROLLOVER_PERIOD; }
            set { _ROLLOVER_PERIOD = value; }
        }

        public const string C_TERM_COMMITMENT = "TERM_COMMITMENT"; // 
        private int? _TERM_COMMITMENT;
        [PropertyEntity(C_TERM_COMMITMENT, false)]
        public int? TERM_COMMITMENT
        {
            get { return _TERM_COMMITMENT; }
            set { _TERM_COMMITMENT = value; }
        }

        public const string C_LISTED_INTEREST_RATE = "LISTED_INTEREST_RATE"; // 
        private decimal? _LISTED_INTEREST_RATE;
        [PropertyEntity(C_LISTED_INTEREST_RATE, false)]
        public decimal? LISTED_INTEREST_RATE
        {
            get { return _LISTED_INTEREST_RATE; }
            set { _LISTED_INTEREST_RATE = value; }
        }

        public const string C_MARGIN_TYPE = "MARGIN_TYPE"; // 
        private int? _MARGIN_TYPE;
        [PropertyEntity(C_MARGIN_TYPE, false)]
        public int? MARGIN_TYPE
        {
            get { return _MARGIN_TYPE; }
            set { _MARGIN_TYPE = value; }
        }

        public const string C_MARGIN_VALUE = "MARGIN_VALUE"; // 
        private decimal? _MARGIN_VALUE;
        [PropertyEntity(C_MARGIN_VALUE, false)]
        public decimal? MARGIN_VALUE
        {
            get { return _MARGIN_VALUE; }
            set { _MARGIN_VALUE = value; }
        }

        public const string C_FINAL_INTEREST_RATE = "FINAL_INTEREST_RATE"; // 
        private decimal? _FINAL_INTEREST_RATE;
        [PropertyEntity(C_FINAL_INTEREST_RATE, false)]
        public decimal? FINAL_INTEREST_RATE
        {
            get { return _FINAL_INTEREST_RATE; }
            set { _FINAL_INTEREST_RATE = value; }
        }

        public const string C_ISSSUED_DATE = "ISSSUED_DATE"; // 
        private DateTime? _ISSSUED_DATE;
        [PropertyEntity(C_ISSSUED_DATE, false)]
        public DateTime? ISSSUED_DATE
        {
            get { return _ISSSUED_DATE; }
            set { _ISSSUED_DATE = value; }
        }

        public const string C_EFFECTIVE_FROM_DATE = "EFFECTIVE_FROM_DATE"; // 
        private DateTime? _EFFECTIVE_FROM_DATE;
        [PropertyEntity(C_EFFECTIVE_FROM_DATE, false)]
        public DateTime? EFFECTIVE_FROM_DATE
        {
            get { return _EFFECTIVE_FROM_DATE; }
            set { _EFFECTIVE_FROM_DATE = value; }
        }

        public const string C_MATURITY_DATE = "MATURITY_DATE"; // 
        private DateTime? _MATURITY_DATE;
        [PropertyEntity(C_MATURITY_DATE, false)]
        public DateTime? MATURITY_DATE
        {
            get { return _MATURITY_DATE; }
            set { _MATURITY_DATE = value; }
        }

        public const string C_MARGIN_APPROVAL_LEVEL = "MARGIN_APPROVAL_LEVEL"; // 
        private int? _MARGIN_APPROVAL_LEVEL;
        [PropertyEntity(C_MARGIN_APPROVAL_LEVEL, false)]
        public int? MARGIN_APPROVAL_LEVEL
        {
            get { return _MARGIN_APPROVAL_LEVEL; }
            set { _MARGIN_APPROVAL_LEVEL = value; }
        }

        public const string C_SALER_CODE = "SALER_CODE"; // 
        private string _SALER_CODE;
        [PropertyEntity(C_SALER_CODE, false)]
        public string SALER_CODE
        {
            get { return _SALER_CODE; }
            set { _SALER_CODE = value; }
        }

        public const string C_SALER_NAME = "SALER_NAME"; // 
        private string _SALER_NAME;
        [PropertyEntity(C_SALER_NAME, false)]
        public string SALER_NAME
        {
            get { return _SALER_NAME; }
            set { _SALER_NAME = value; }
        }

        public const string C_INTRODUCER_CODE = "INTRODUCER_CODE"; // 
        private string _INTRODUCER_CODE;
        [PropertyEntity(C_INTRODUCER_CODE, false)]
        public string INTRODUCER_CODE
        {
            get { return _INTRODUCER_CODE; }
            set { _INTRODUCER_CODE = value; }
        }

        public const string C_INTRODUCER_NAME = "INTRODUCER_NAME"; // 
        private string _INTRODUCER_NAME;
        [PropertyEntity(C_INTRODUCER_NAME, false)]
        public string INTRODUCER_NAME
        {
            get { return _INTRODUCER_NAME; }
            set { _INTRODUCER_NAME = value; }
        }

        public const string C_PRODUCT_SPECIFIC_ID = "PRODUCT_SPECIFIC_ID"; // 
        private int? _PRODUCT_SPECIFIC_ID;
        [PropertyEntity(C_PRODUCT_SPECIFIC_ID, false)]
        public int? PRODUCT_SPECIFIC_ID
        {
            get { return _PRODUCT_SPECIFIC_ID; }
            set { _PRODUCT_SPECIFIC_ID = value; }
        }

        public const string C_DESCRIPTION = "DESCRIPTION"; // 
        private string _DESCRIPTION;
        [PropertyEntity(C_DESCRIPTION, false)]
        public string DESCRIPTION
        {
            get { return _DESCRIPTION; }
            set { _DESCRIPTION = value; }
        }

        public const string C_PAYIN_ACCOUNT = "PAYIN_ACCOUNT"; // 
        private string _PAYIN_ACCOUNT;
        [PropertyEntity(C_PAYIN_ACCOUNT, false)]
        public string PAYIN_ACCOUNT
        {
            get { return _PAYIN_ACCOUNT; }
            set { _PAYIN_ACCOUNT = value; }
        }

        public const string C_PAYIN_ADDITION_CASH = "PAYIN_ADDITION_CASH"; // 
        private decimal? _PAYIN_ADDITION_CASH;
        [PropertyEntity(C_PAYIN_ADDITION_CASH, false)]
        public decimal? PAYIN_ADDITION_CASH
        {
            get { return _PAYIN_ADDITION_CASH; }
            set { _PAYIN_ADDITION_CASH = value; }
        }

        public const string C_PAYIN_AUTO_DEBIT = "PAYIN_AUTO_DEBIT"; // 
        private bool? _PAYIN_AUTO_DEBIT;
        [PropertyEntity(C_PAYIN_AUTO_DEBIT, false)]
        public bool? PAYIN_AUTO_DEBIT
        {
            get { return _PAYIN_AUTO_DEBIT; }
            set { _PAYIN_AUTO_DEBIT = value; }
        }

        public const string C_PAYIN_AUTO_DEBIT_ACCOUNT = "PAYIN_AUTO_DEBIT_ACCOUNT"; // 
        private string _PAYIN_AUTO_DEBIT_ACCOUNT;
        [PropertyEntity(C_PAYIN_AUTO_DEBIT_ACCOUNT, false)]
        public string PAYIN_AUTO_DEBIT_ACCOUNT
        {
            get { return _PAYIN_AUTO_DEBIT_ACCOUNT; }
            set { _PAYIN_AUTO_DEBIT_ACCOUNT = value; }
        }

        public const string C_PAYIN_AUTO_DEBIT_AMOUNT = "PAYIN_AUTO_DEBIT_AMOUNT"; // 
        private decimal? _PAYIN_AUTO_DEBIT_AMOUNT;
        [PropertyEntity(C_PAYIN_AUTO_DEBIT_AMOUNT, false)]
        public decimal? PAYIN_AUTO_DEBIT_AMOUNT
        {
            get { return _PAYIN_AUTO_DEBIT_AMOUNT; }
            set { _PAYIN_AUTO_DEBIT_AMOUNT = value; }
        }

        public const string C_PAYIN_AUTO_DEBIT_DATE = "PAYIN_AUTO_DEBIT_DATE"; // 
        private int? _PAYIN_AUTO_DEBIT_DATE;
        [PropertyEntity(C_PAYIN_AUTO_DEBIT_DATE, false)]
        public int? PAYIN_AUTO_DEBIT_DATE
        {
            get { return _PAYIN_AUTO_DEBIT_DATE; }
            set { _PAYIN_AUTO_DEBIT_DATE = value; }
        }

        public const string C_PAYOUT_PRINCIPAL_ACCOUNT = "PAYOUT_PRINCIPAL_ACCOUNT"; // 
        private string _PAYOUT_PRINCIPAL_ACCOUNT;
        [PropertyEntity(C_PAYOUT_PRINCIPAL_ACCOUNT, false)]
        public string PAYOUT_PRINCIPAL_ACCOUNT
        {
            get { return _PAYOUT_PRINCIPAL_ACCOUNT; }
            set { _PAYOUT_PRINCIPAL_ACCOUNT = value; }
        }

        public const string C_PAYOUT_INTEREST_ACCOUNT = "PAYOUT_INTEREST_ACCOUNT"; // 
        private string _PAYOUT_INTEREST_ACCOUNT;
        [PropertyEntity(C_PAYOUT_INTEREST_ACCOUNT, false)]
        public string PAYOUT_INTEREST_ACCOUNT
        {
            get { return _PAYOUT_INTEREST_ACCOUNT; }
            set { _PAYOUT_INTEREST_ACCOUNT = value; }
        }


        public sav_ArrangementRequestChangeOld() : base("SAV_ARRANGEMENT_REQUEST_CHANGE_OLD", "ARRANGEMENT_REQUEST_CHANGE_OLD_ID", false, false) { }

        #endregion

        #region Extend members
        [PropertyEntity("CUSTOMER_TYPE_NAME", false, false)]
        public string CUSTOMER_TYPE_NAME { get; set; }

        [PropertyEntity("CUSTOMER_RANK_NAME", false, false)]
        public string CUSTOMER_RANK_NAME { get; set; }

        [PropertyEntity("CUSTOMER_IDENTIFICATION_TYPE_NAME", false, false)]
        public string CUSTOMER_IDENTIFICATION_TYPE_NAME { get; set; }

        [PropertyEntity("CUSTOMER_NATIONALITY_NAME", false, false)]
        public string CUSTOMER_NATIONALITY_NAME { get; set; }

        [PropertyEntity("CUSTOMER_NATIONALITY_CODE", false, false)]
        public string CUSTOMER_NATIONALITY_CODE { get; set; }

        [PropertyEntity("PRODUCT_NAME", false, false)]
        public string PRODUCT_NAME { get; set; }

        [PropertyEntity("CURRENCY_CODE", false, false)]
        public string CURRENCY_CODE { get; set; }

        [PropertyEntity("ROLLOVER_METHOD_NAME", false, false)]
        public string ROLLOVER_METHOD_NAME { get; set; }

        [PropertyEntity("INTEREST_PAYMENT_METHOD_NAME", false, false)]
        public string INTEREST_PAYMENT_METHOD_NAME { get; set; }

        [PropertyEntity("INTEREST_PAYMENT_TERM_NAME", false, false)]
        public string INTEREST_PAYMENT_TERM_NAME { get; set; }

        [PropertyEntity("ROLLOVER_PERIOD_NAME", false, false)]
        public string ROLLOVER_PERIOD_NAME { get; set; }

        [PropertyEntity("TERM_COMMITMENT_NAME", false, false)]
        public string TERM_COMMITMENT_NAME { get; set; }

        [PropertyEntity("MARGIN_APPROVAL_LEVEL_NAME", false, false)]
        public string MARGIN_APPROVAL_LEVEL_NAME { get; set; }

        [PropertyEntity("MARGIN_TYPE_NAME", false, false)]
        public string MARGIN_TYPE_NAME { get; set; }

        [PropertyEntity("PRODUCT_TYPE", false, false)]
        public int? PRODUCT_TYPE { get; set; }

        [PropertyEntity("PRODUCT_CODE", false, false)]
        public string PRODUCT_CODE { get; set; }

        [PropertyEntity("Fund_Name", false, false)]
        public string Fund_Name { get; set; }
        public string APPROVAL_STATUS_NAME { get; set; }
        public string APPROVAL_STATUS_COLOR { get; set; }

        [PropertyEntity("PAYOUT_PRINCIPAL_DES", false, false)]
        public string PAYOUT_PRINCIPAL_DES { get; set; }
        [PropertyEntity("PAYOUT_INTEREST_DES", false, false)]
        public string PAYOUT_INTEREST_DES { get; set; }
        [PropertyEntity("INTEREST_PAYMENT_PERIOD", false, false)]
        public string INTEREST_PAYMENT_PERIOD { get; set; }
        [PropertyEntity("DAO_CODE", false, false)]
        public string DAO_CODE { get; set; }
        #endregion

        #region Clone

        public sav_ArrangementRequestChangeOld CloneToInsert()
        {
            sav_ArrangementRequestChangeOld newItem = new sav_ArrangementRequestChangeOld();

            newItem.ARRANGEMENT_REQUEST_CHANGE_OLD_ID = this.ARRANGEMENT_REQUEST_CHANGE_OLD_ID;
            newItem.ARRANGEMENT_REQUEST_CHANGE_ID = this.ARRANGEMENT_REQUEST_CHANGE_ID;
            newItem.ARRANGEMENT_ID = this.ARRANGEMENT_ID;
            newItem.PRODUCT_ID = this.PRODUCT_ID;
            newItem.CUSTOMER_CODE = this.CUSTOMER_CODE;
            newItem.CUSTOMER_NAME = this.CUSTOMER_NAME;
            newItem.CUSTOMER_TYPE = this.CUSTOMER_TYPE;
            newItem.CUSTOMER_RANK = this.CUSTOMER_RANK;
            newItem.CUSTOMER_IDENTIFICATION_TYPE = this.CUSTOMER_IDENTIFICATION_TYPE;
            newItem.CUSTOMER_IDENTIFICATION_NO = this.CUSTOMER_IDENTIFICATION_NO;
            newItem.CUSTOMER_IDENTIFICATION_DATE = this.CUSTOMER_IDENTIFICATION_DATE;
            newItem.CUSTOMER_IDENTIFICATION_PLACE = this.CUSTOMER_IDENTIFICATION_PLACE;
            newItem.CUSTOMER_NATIONALITY_ID = this.CUSTOMER_NATIONALITY_ID;
            newItem.CUSTOMER_BIRTH_DATE = this.CUSTOMER_BIRTH_DATE;
            newItem.CUSTOMER_GENDER = this.CUSTOMER_GENDER;
            newItem.CUSTOMER_PHONE = this.CUSTOMER_PHONE;
            newItem.CUSTOMER_ADDRESS = this.CUSTOMER_ADDRESS;
            newItem.CUSTOMER_RESIDENT_FROM_DATE = this.CUSTOMER_RESIDENT_FROM_DATE;
            newItem.CUSTOMER_RESIDENT_TO_DATE = this.CUSTOMER_RESIDENT_TO_DATE;
            newItem.SERIAL_NUMBER = this.SERIAL_NUMBER;
            newItem.AA_DEPOSIT_ID = this.AA_DEPOSIT_ID;
            newItem.AA_ACCOUNT = this.AA_ACCOUNT;
            newItem.AA_LIVE = this.AA_LIVE;
            newItem.PRINTED_OWNER_NAME = this.PRINTED_OWNER_NAME;
            newItem.CURRENCY_ID = this.CURRENCY_ID;
            newItem.PAYIN_AMOUNT = this.PAYIN_AMOUNT;
            newItem.ACCURAL_AMOUNT = this.ACCURAL_AMOUNT;
            newItem.ESTIMATED_INTEREST_AMOUNT = this.ESTIMATED_INTEREST_AMOUNT;
            newItem.ROLLOVER_METHOD = this.ROLLOVER_METHOD;
            newItem.INTEREST_PAYMENT_METHOD = this.INTEREST_PAYMENT_METHOD;
            newItem.INTEREST_PAYMENT_TERM = this.INTEREST_PAYMENT_TERM;
            newItem.ROLLOVER_PERIOD = this.ROLLOVER_PERIOD;
            newItem.TERM_COMMITMENT = this.TERM_COMMITMENT;
            newItem.LISTED_INTEREST_RATE = this.LISTED_INTEREST_RATE;
            newItem.MARGIN_TYPE = this.MARGIN_TYPE;
            newItem.MARGIN_VALUE = this.MARGIN_VALUE;
            newItem.FINAL_INTEREST_RATE = this.FINAL_INTEREST_RATE;
            newItem.ISSSUED_DATE = this.ISSSUED_DATE;
            newItem.EFFECTIVE_FROM_DATE = this.EFFECTIVE_FROM_DATE;
            newItem.MATURITY_DATE = this.MATURITY_DATE;
            newItem.MARGIN_APPROVAL_LEVEL = this.MARGIN_APPROVAL_LEVEL;
            newItem.SALER_CODE = this.SALER_CODE;
            newItem.SALER_NAME = this.SALER_NAME;
            newItem.INTRODUCER_CODE = this.INTRODUCER_CODE;
            newItem.INTRODUCER_NAME = this.INTRODUCER_NAME;
            newItem.PRODUCT_SPECIFIC_ID = this.PRODUCT_SPECIFIC_ID;
            newItem.DESCRIPTION = this.DESCRIPTION;
            newItem.PAYIN_ACCOUNT = this.PAYIN_ACCOUNT;
            newItem.PAYIN_ADDITION_CASH = this.PAYIN_ADDITION_CASH;
            newItem.PAYIN_AUTO_DEBIT = this.PAYIN_AUTO_DEBIT;
            newItem.PAYIN_AUTO_DEBIT_ACCOUNT = this.PAYIN_AUTO_DEBIT_ACCOUNT;
            newItem.PAYIN_AUTO_DEBIT_AMOUNT = this.PAYIN_AUTO_DEBIT_AMOUNT;
            newItem.PAYIN_AUTO_DEBIT_DATE = this.PAYIN_AUTO_DEBIT_DATE;
            newItem.PAYOUT_PRINCIPAL_ACCOUNT = this.PAYOUT_PRINCIPAL_ACCOUNT;
            newItem.PAYOUT_INTEREST_ACCOUNT = this.PAYOUT_INTEREST_ACCOUNT;

            return newItem;
        }

        public sav_ArrangementRequestChangeOld CloneToUpdate()
        {
            sav_ArrangementRequestChangeOld newItem = new sav_ArrangementRequestChangeOld();

            newItem.ARRANGEMENT_REQUEST_CHANGE_OLD_ID = this.ARRANGEMENT_REQUEST_CHANGE_OLD_ID;
            newItem.ARRANGEMENT_REQUEST_CHANGE_ID = this.ARRANGEMENT_REQUEST_CHANGE_ID;
            newItem.ARRANGEMENT_ID = this.ARRANGEMENT_ID;
            newItem.PRODUCT_ID = this.PRODUCT_ID;
            newItem.CUSTOMER_CODE = this.CUSTOMER_CODE;
            newItem.CUSTOMER_NAME = this.CUSTOMER_NAME;
            newItem.CUSTOMER_TYPE = this.CUSTOMER_TYPE;
            newItem.CUSTOMER_RANK = this.CUSTOMER_RANK;
            newItem.CUSTOMER_IDENTIFICATION_TYPE = this.CUSTOMER_IDENTIFICATION_TYPE;
            newItem.CUSTOMER_IDENTIFICATION_NO = this.CUSTOMER_IDENTIFICATION_NO;
            newItem.CUSTOMER_IDENTIFICATION_DATE = this.CUSTOMER_IDENTIFICATION_DATE;
            newItem.CUSTOMER_IDENTIFICATION_PLACE = this.CUSTOMER_IDENTIFICATION_PLACE;
            newItem.CUSTOMER_NATIONALITY_ID = this.CUSTOMER_NATIONALITY_ID;
            newItem.CUSTOMER_BIRTH_DATE = this.CUSTOMER_BIRTH_DATE;
            newItem.CUSTOMER_GENDER = this.CUSTOMER_GENDER;
            newItem.CUSTOMER_PHONE = this.CUSTOMER_PHONE;
            newItem.CUSTOMER_ADDRESS = this.CUSTOMER_ADDRESS;
            newItem.CUSTOMER_RESIDENT_FROM_DATE = this.CUSTOMER_RESIDENT_FROM_DATE;
            newItem.CUSTOMER_RESIDENT_TO_DATE = this.CUSTOMER_RESIDENT_TO_DATE;
            newItem.SERIAL_NUMBER = this.SERIAL_NUMBER;
            newItem.AA_DEPOSIT_ID = this.AA_DEPOSIT_ID;
            newItem.AA_ACCOUNT = this.AA_ACCOUNT;
            newItem.AA_LIVE = this.AA_LIVE;
            newItem.PRINTED_OWNER_NAME = this.PRINTED_OWNER_NAME;
            newItem.CURRENCY_ID = this.CURRENCY_ID;
            newItem.PAYIN_AMOUNT = this.PAYIN_AMOUNT;
            newItem.ACCURAL_AMOUNT = this.ACCURAL_AMOUNT;
            newItem.ESTIMATED_INTEREST_AMOUNT = this.ESTIMATED_INTEREST_AMOUNT;
            newItem.ROLLOVER_METHOD = this.ROLLOVER_METHOD;
            newItem.INTEREST_PAYMENT_METHOD = this.INTEREST_PAYMENT_METHOD;
            newItem.INTEREST_PAYMENT_TERM = this.INTEREST_PAYMENT_TERM;
            newItem.ROLLOVER_PERIOD = this.ROLLOVER_PERIOD;
            newItem.TERM_COMMITMENT = this.TERM_COMMITMENT;
            newItem.LISTED_INTEREST_RATE = this.LISTED_INTEREST_RATE;
            newItem.MARGIN_TYPE = this.MARGIN_TYPE;
            newItem.MARGIN_VALUE = this.MARGIN_VALUE;
            newItem.FINAL_INTEREST_RATE = this.FINAL_INTEREST_RATE;
            newItem.ISSSUED_DATE = this.ISSSUED_DATE;
            newItem.EFFECTIVE_FROM_DATE = this.EFFECTIVE_FROM_DATE;
            newItem.MATURITY_DATE = this.MATURITY_DATE;
            newItem.MARGIN_APPROVAL_LEVEL = this.MARGIN_APPROVAL_LEVEL;
            newItem.SALER_CODE = this.SALER_CODE;
            newItem.SALER_NAME = this.SALER_NAME;
            newItem.INTRODUCER_CODE = this.INTRODUCER_CODE;
            newItem.INTRODUCER_NAME = this.INTRODUCER_NAME;
            newItem.PRODUCT_SPECIFIC_ID = this.PRODUCT_SPECIFIC_ID;
            newItem.DESCRIPTION = this.DESCRIPTION;
            newItem.PAYIN_ACCOUNT = this.PAYIN_ACCOUNT;
            newItem.PAYIN_ADDITION_CASH = this.PAYIN_ADDITION_CASH;
            newItem.PAYIN_AUTO_DEBIT = this.PAYIN_AUTO_DEBIT;
            newItem.PAYIN_AUTO_DEBIT_ACCOUNT = this.PAYIN_AUTO_DEBIT_ACCOUNT;
            newItem.PAYIN_AUTO_DEBIT_AMOUNT = this.PAYIN_AUTO_DEBIT_AMOUNT;
            newItem.PAYIN_AUTO_DEBIT_DATE = this.PAYIN_AUTO_DEBIT_DATE;
            newItem.PAYOUT_PRINCIPAL_ACCOUNT = this.PAYOUT_PRINCIPAL_ACCOUNT;
            newItem.PAYOUT_INTEREST_ACCOUNT = this.PAYOUT_INTEREST_ACCOUNT;

            return newItem;
        }

        public override void SetId(int id)
        {
            throw new NotImplementedException();
        }

        public override int GetId()
        {
            throw new NotImplementedException();
        }

        public override void SetVersion(int version)
        {
            throw new NotImplementedException();
        }

        public override void SetDeleted(bool isDeleted)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
