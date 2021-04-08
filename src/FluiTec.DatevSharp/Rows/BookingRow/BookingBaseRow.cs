using System;

namespace FluiTec.DatevSharp.Rows.BookingRow
{
	public partial class BookingRow
	{
		/// <summary>   Gets or sets the volume. </summary>
		///
		/// <value> The volume. </value>
		/// <remarks>
		/// MaxLength=13
		/// </remarks>
		public decimal Volume { get; set; }

		/// <summary>   Gets or sets the claim. </summary>
		///
		/// <value> The claim. </value>
		/// <remarks>
		/// S/H (Soll/Haben)         
		/// </remarks>
		public string Claim { get; set; }

		/// <summary>   Gets or sets the currency symbol. </summary>
		///
		/// <value> The currency symbol. </value>
		/// <remarks>
		/// MaxLength=3, ISO 4217, see https://msdn.microsoft.com/de-de/library/system.globalization.regioninfo.isocurrencysymbol(v=vs.110).aspx
		/// </remarks>
		public string CurrencySymbol { get; set; }

		/// <summary>   Gets or sets the exchange rage. </summary>
		///
		/// <value> The exchange rage. </value>
		/// <remarks>
		/// Must be either NULL OR > 0         
		/// </remarks>
		public decimal? ExchangeRage { get; set; }

		/// <summary>   Gets or sets the basic volume. </summary>
		///
		/// <value> The basic volume. </value>
		public decimal? BasicVolume { get; set; }

		/// <summary>   Gets or sets the basic volume currency symbol. </summary>
		///
		/// <value> The basic volume currency symbol. </value>
		/// <remarks>
		/// Can be NULL
		/// MaxLength=3, ISO 4217, see https://msdn.microsoft.com/de-de/library/system.globalization.regioninfo.isocurrencysymbol(v=vs.110).aspx
		/// </remarks>
		public string BasicVolumeCurrencySymbol { get; set; }

		/// <summary>   Gets or sets the account number. </summary>
		///
		/// <value> The account number. </value>
		/// <remarks>
		/// MaxLength=9         
		/// </remarks>
		public string AccountNumber { get; set; }

		/// <summary>   Gets or sets the contra account number. </summary>
		///
		/// <value> The contra account number. </value>
		/// <remarks>
		/// MaxLength=9         
		/// </remarks>
		public string ContraAccountNumber { get; set; }

		/// <summary>   Gets or sets the tax key. </summary>
		///
		/// <value> The tax key. </value>
		/// <remarks>
		/// BU-Schlüssel, Length=2-4         
		/// </remarks>
		public string TaxKey { get; set; }

		/// <summary>   Gets or sets the Date/Time of the date. </summary>
		///
		/// <value> The date. </value>
		/// <remarks>
		/// Not Null         
		/// </remarks>
		public DateTime? Date { get; set; }

		/// <summary>   Gets or sets the document field 1. </summary>
		///
		/// <value> The document field 1. </value>
		/// <remarks>
		/// MaxLength=36         
		/// </remarks>
		public string DocumentField1 { get; set; }

		/// <summary>   Gets or sets the document field 2. </summary>
		///
		/// <value> The document field 2. </value>
		/// <remarks>
		/// MaxLength=12         
		/// </remarks>
		public string DocumentField2 { get; set; }

		/// <summary>   Gets or sets the cash discount. </summary>
		///
		/// <value> The cash discount. </value>
		/// <remarks>
		/// Must not be 0, NULL however is allowed         
		/// </remarks>
		public decimal? CashDiscount { get; set; }

        /// <summary>   Gets or sets the type of the cash discount. </summary>
        ///
        /// <value> The type of the cash discount. </value>
		/// <remarks>
        /// MaxLength=1,
        /// 1 = Einkauf von Waren
        /// 2 = Erwerb von Roh-Hilfs- und Betriebsstoffen
		/// </remarks>
		public int? CashDiscountType { get; set; }

        /// <summary>   Gets or sets the cash discount block. </summary>
        ///
        /// <value> The cash discount block. </value>
		public bool? CashDiscountBlock { get; set; }

		/// <summary>   Gets or sets the booking text. </summary>
		///
		/// <value> The booking text. </value>
		/// <remarks>
		/// MaxLength=60         
		/// </remarks>
		public string BookingText { get; set; }

		/// <summary>   Gets or sets the blocked. </summary>
		///
		/// <value> The blocked. </value>
		public bool? Blocked { get; set; }

		/// <summary>   Gets or sets the diverse account number. </summary>
		///
		/// <value> The diverse account number. </value>
		/// <remarks>
		/// MaxLenght=9         
		/// </remarks>
		public string DiverseAccountNumber { get; set; }

		/// <summary>   Gets or sets the partner bank. </summary>
		///
		/// <value> The partner bank. </value>
		/// <remarks>
		/// MaxLength=3
		/// </remarks>
		public string PartnerBank { get; set; }

		/// <summary>   Gets or sets the circumstances. </summary>
		///
		/// <value> The circumstances. </value>
		/// <remarks>
		/// MaxLength=2
		/// 31 = Mahnzins
		/// 40 = Mahngebühr
		/// </remarks>
		public string Circumstances { get; set; }

		/// <summary>   Gets or sets a value indicating whether the interest block. </summary>
		///
		/// <value> true if interest block, false if not. </value>
		/// <remarks>
		/// Zinsberechnungssperre         
		/// </remarks>
		public bool? InterestBlock { get; set; }

		/// <summary>   Gets or sets the document link. </summary>
		///
		/// <value> The document link. </value>
		/// <remarks>
		/// MaxLength=210         
		/// </remarks>
		public string DocumentLink { get; set; }

		/// <summary>   Gets or sets the type of the booking. </summary>
		///
		/// <value> The type of the booking. </value>
		/// <remarks>
		/// MaxLength=2
		/// AA = Angeforderte Anzahlung/
		///		 Abschlagsrechnung
		/// AG = Erhaltene Anzahlung(Geldeingang)
		/// AV = Erhaltene Anzahlung(Verbindlichkeit)
		/// SR = Schlussrechnung
		/// SU = Schlussrechnung(Umbuchung)
		/// SG = Schlussrechnung(Geldeingang)
		/// SO = Sonstige
		/// </remarks>
		public string BookingType { get; set; }

        /// <summary>   Gets or sets the type of the payment. </summary>
        ///
        /// <value> The type of the payment. </value>
		/// <remarks>
        /// MaxLength=2
        /// 1 = Lastschrift
        /// 2 = Mahnung
        /// 3 = Zahlung
		/// </remarks>
		public int? PaymentType { get; set; }

        /// <summary>   Gets or sets the proprietor. </summary>
        ///
        /// <value> The proprietor. </value>
		/// <remarks>
        /// MaxLength=76         
        /// </remarks>
		public string Proprietor { get; set; }

        /// <summary>   Gets or sets a value indicating whether the fixing. </summary>
        ///
        /// <value> true if fixing, false if not. </value>
		/// <remarks>
        /// Default=false         
        /// </remarks>
		public bool Fixing { get; set; }

        /// <summary>   Gets or sets the activity date. </summary>
        ///
        /// <value> The activity date. </value>
		public DateTime? ActivityDate { get; set; }

		/// <summary>	Gets or sets the due date. </summary>
		/// 
		/// <value> The due date of the payment. </value>
		/// <remarks>
		/// OPOS Information
		/// </remarks>
		public DateTime? DueDate { get; set; }

		/// <summary>	Gets or sets the general inversion. </summary>
		/// 
		/// <value> 1 for invert another booking row. 0 for normal booking row. </value>
		/// <remarks>
		/// Default=0
		/// </remarks>
		public string GeneralInversion { get; set; }

		/// <summary>	Gets or sets the Taxrate. </summary>
		/// 
		/// <value> The tax rate. </value>
		/// <remarks>
		/// MinLength=2
		/// MaxLength=5
		/// </remarks>
		public int? TaxRate { get; set; }

		/// <summary>	Gets or sets the country </summary>
		/// 
		/// <value> The country in 2 digits. See https://www.iso.org/iso-3166-country-codes.html for more information</value>
		/// <remarks>
		/// MaxLength=2
		/// Example: DE for Germany
		/// </remarks>
		public string Country { get; set; }
	}
}