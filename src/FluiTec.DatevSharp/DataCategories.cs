using System;
using FluiTec.DatevSharp.Interfaces;
using FluiTec.DatevSharp.Rows.Headers;

namespace FluiTec.DatevSharp
{
	/// <summary>   A data categories. </summary>
	public static class DataCategories
	{
		/// <summary>   The bookings. </summary>
		public static DataCategory Bookings => new DataCategory(21, "Buchungsstapel", 9);

		/// <summary>   The recurring bookings. </summary>
		public static DataCategory RecurringBookings => new DataCategory(65, "Wiederkehrende Buchungen", 2);

		/// <summary>   The booking text constants. </summary>
		public static DataCategory BookingTextConstants => new DataCategory(67, "Buchungstextkonstanten", 1);

		/// <summary>   List of names of the nominal accounts. </summary>
		public static DataCategory NominalAccountNames => new DataCategory(20, "Kontenbeschriftungen", 2);

		/// <summary>   The account notes. </summary>
		public static DataCategory AccountNotes => new DataCategory(47, "Konto-Notizen", 1);

		/// <summary>   The addresses. </summary>
		public static DataCategory Addresses => new DataCategory(16, "Debitoren/Kreditoren", 4);

		/// <summary>   The text keys. </summary>
		public static DataCategory TextKeys => new DataCategory(44, "Textschlüssel", 2);

		/// <summary>   The terms of payment. </summary>
		public static DataCategory TermsOfPayment => new DataCategory(46, "Zahlungsbedingungen", 2);

		/// <summary>   The misc addresses. </summary>
		public static DataCategory MiscAddresses => new DataCategory(48, " Diverse Adressen", 2);

		/// <summary>   The system bookings. </summary>
		public static DataCategory SystemBookings => new DataCategory(63, "Anlagenbuchführung – Buchungssatzvorlagen", 1);

		/// <summary>   The system branches. </summary>
		public static DataCategory SystemBranches => new DataCategory(62, "Anlagenbuchführung – Filialen", 1);

		/// <summary>   Gets header row. </summary>
		///
		/// <param name="category"> The category. </param>
		///
		/// <returns>   The header row. </returns>
		public static IDatevRow GetHeaderRow(DataCategory category)
		{
			switch (category.Number)
			{
				case 16: // Debitoren/Kreditoren
					switch (category.Version)
					{
						case 4:
							return new AddressHeaderRow();
						default:
							throw new NotImplementedException();
					}
				case 21: // Buchungsstapel
					switch (category.Version)
					{
						case 9:
							return new BookingHeaderRow();
						default:
							throw new NotImplementedException();
					}
				case 46: // Zahlungsbedingungen
					switch (category.Version)
					{
						case 2:
							return new TermsOfPaymentHeaderRow();
						default:
							throw new NotImplementedException();
					}
				default:
					throw new NotImplementedException();
			}
		}
	}
}