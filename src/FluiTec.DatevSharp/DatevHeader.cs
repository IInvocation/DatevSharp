using System;
using System.Data;
using System.Globalization;
using FluentValidation;
using FluiTec.DatevSharp.Helpers;
using FluiTec.DatevSharp.Interfaces;
using FluiTec.DatevSharp.Validation;

namespace FluiTec.DatevSharp
{
    /// <summary>   A datev header. </summary>
	public class DatevHeader : IDatevRow
	{
		#region BasicHeaderProperties

		/// <summary>   Identifier for the format. Static: "EXTF"</summary>
		public string FormatIdentifier => "EXTF";

        /// <summary>   The version of the export file. </summary>
		public int Version => 700;

        /// <summary>   Category the data belongs to. </summary>
		public DataCategory DataCategory { get; set; }

        /// <summary>   Gets or sets the Date/Time of the created. </summary>
        ///
        /// <value> The created. </value>
		public DateTime Created { get; }

        /// <summary>   Gets or sets the Date/Time when the fle was imported. </summary>
        ///
        /// <value> The imported datetime. </value>
		public DateTime? Imported { get; set; }

        /// <summary>   Gets or sets the source for the. </summary>
        ///
        /// <value> The source. </value>
        /// <remarks>
        /// Maximum length = 2         
        /// </remarks>
	    public string Source { get; set; }

        /// <summary>   Gets or sets who exported this object. </summary>
        ///
        /// <value> Describes who exported this object. </value>
		public string ExportedBy { get; set; }

        /// <summary>   Gets or sets who imported this object. </summary>
        ///
        /// <value> Describes who imported this object. </value>
		public string ImportedBy { get; set; }

        /// <summary>   Gets or sets the consultant number. </summary>
        ///
        /// <value> The consultant number. </value>
        /// <remarks>
        /// Must be > 0         
        /// </remarks>
		public int ConsultantNumber { get; set; }

        /// <summary>   Gets or sets the client number. </summary>
        ///
        /// <value> The client number. </value>
        /// <remarks>
        /// Must be > 0         
        /// </remarks>
		public int ClientNumber { get; set; }

        /// <summary>   Gets or sets the Date/Time of the start of business year. </summary>
        ///
        /// <value> The start of business year. </value>
        /// <remarks>
        /// Must be less than or equal to Created-Date.         
        /// </remarks>
		public DateTime StartOfBusinessYear { get; set; }

        /// <summary>   Gets or sets the length of the impersonal accounts. </summary>
        ///
        /// <value> The length of the impersonal accounts. </value>
        /// <remarks>
        /// Must be:
        /// Greater than 0
        /// Less than or equal to 9         
        /// </remarks>
		public int ImpersonalAccountsLength { get; set; }

		#endregion

		#region BookingHeaderProperties

        /// <summary>   Gets or sets the Date/Time of the bookings from. </summary>
        ///
        /// <value> The bookings from. </value>
        /// <remarks>
        /// Must not be null for bookings.         
        /// </remarks>
		public DateTime? BookingsFrom { get; set; }

        /// <summary>   Gets or sets the Date/Time of the bookings till. </summary>
        ///
        /// <value> The bookings till. </value>
        /// <remarks>
        /// Must not be null for bookings         
        /// </remarks>
		public DateTime? BookingsTill { get; set; }

        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        /// <remarks>
        /// e.g. "Rechnungen März", MaxLength=30
        /// </remarks>
		public string Description { get; set; }

        /// <summary>   Gets or sets the name of the dictation short. </summary>
        ///
        /// <value> The name of the dictation short. </value>
        /// <remarks>
        /// "MM"  --> Max Mustermann, MaxLength=2        
        /// </remarks>
		public string DictationShortName { get; set; }

        /// <summary>   Gets or sets the type of the booking. </summary>
        ///
        /// <value> The type of the booking. </value>
        /// <remarks>
        /// 1 = Finanzbuchhaltung  
        /// 2 = Jahresabschluss         
        /// </remarks>
		public int? BookingType { get; set; }

        /// <summary>   Gets or sets the billing intention. </summary>
        ///
        /// <value> The billing intention. </value>
        /// <remarks>
        /// 0 oder leer = vom Rechnungslegungszweck unabhängig
        /// 50 = Handelsrecht
        /// 30 = Steuerrecht
        /// 64 = IFRS
        /// 40 = Kalkulatorik
        /// 11 = Reserviert
        /// 12 = Reserviert
		/// </remarks>
		public int? BillingIntention { get; set; }

        /// <summary>   Gets or sets a value indicating whether the fixing. </summary>
        ///
        /// <value> true if fixing, false if not. </value>
        /// <remarks>
        /// leer = nicht definiert; wird ab Jahreswechselversion
        /// 2016/2017 automatisch festgeschrieben
        /// 0 = keine Festschreibung
        /// 1 = Festschreibung
		/// </remarks>
		public bool Fixing { get; set; }

		/// <summary>   Gets or sets the currency symbol. </summary>
		///
		/// <value> The currency symbol. </value>
		/// <remarks>
		/// MaxLength=3, ISO 4217, see https://msdn.microsoft.com/de-de/library/system.globalization.regioninfo.isocurrencysymbol(v=vs.110).aspx
		/// </remarks>
		public string CurrencySymbol { get; set; }

		#endregion

		#region Constructors

		/// <summary>   Default constructor. </summary>
		public DatevHeader()
		{
			Created = DateTime.Now;
			ExportedBy = Environment.UserName;
			StartOfBusinessYear = new DateTime(Created.Year, 1, 1);
			ImpersonalAccountsLength = 4;
			BookingType = 1;
			BillingIntention = 0;
			Fixing = false;
			CurrencySymbol = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID).ISOCurrencySymbol;
		}

		#endregion

		#region Methods

        /// <summary>   Converts this object to a row. </summary>
        ///
        /// <returns>   This object as a string. </returns>
		public string ToRow()
        {
	        return
		        $"{FormatIdentifier.ToDatev()};{Version};{DataCategory.Number};{DataCategory.Name.ToDatev()};{DataCategory.Version};" +
		        $"{Created.ToDatevDateTime()};{Imported};{Source.ToDatev()};{ExportedBy.ToDatev()};{ImportedBy.ToDatev()};" +
		        $"{ConsultantNumber};{ClientNumber};{StartOfBusinessYear.ToDatevDate()};{ImpersonalAccountsLength};" +
		        $"{BookingsFrom.ToDatevDate()};{BookingsTill.ToDatevDate()};{Description.ToDatev()};{DictationShortName.ToDatev()};" +
		        $"{BookingType};{BillingIntention};{Fixing.ToDatev()};{CurrencySymbol.ToDatev()};;;;;;;;;";
        }

        /// <summary>   Gets the validator needed for the given format. </summary>
        ///
        /// <returns>   The validator for the given format. </returns>
	    public IValidator<IDatevRow> GetValidator()
	    {
		    if (DataCategory == null)
				throw new NoNullAllowedException($"{nameof(DataCategory)} must not be null for this method to succeed.");
	        switch (DataCategory.Number)
	        {
				case 16:
					return new AddressRowValidator(ImpersonalAccountsLength + 1);
				case 21:
			        return new BookingRowValidator(ImpersonalAccountsLength);
				case 46:
			        return new TermsOfPaymentRowValidator();
				default:
					throw new ArgumentException($"{nameof(DataCategory)} with value {DataCategory.Number} is not implemented yet.");
	        }
	    }
 
		#endregion
	}
}