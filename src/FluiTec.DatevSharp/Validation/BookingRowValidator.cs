using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using FluiTec.DatevSharp.Interfaces;
using FluiTec.DatevSharp.Rows.BookingRow;

namespace FluiTec.DatevSharp.Validation
{
    /// <summary>   A booking validator. </summary>
	public class BookingRowValidator : AbstractValidator<BookingRow>, IValidator<IDatevRow>
    {
        /// <summary>   Default constructor. </summary>
        /// <param name="impersonalAccountsLength">    Length of the account. </param>
        public BookingRowValidator(int impersonalAccountsLength)
        {
            AddBasicRules(impersonalAccountsLength);
            AddBookingInfoRules();
            AddMiscRuls();
            AddAdditionInfoRules();
        }

        private void AddBasicRules(int impersonalAccountsLength)
        {
            RuleFor(booking => booking.Volume).GreaterThan(0);
            RuleFor(booking => booking.Volume).LessThanOrEqualTo(9999999999.99m); // avoid havin length>13
            RuleFor(booking => booking.Claim).Must(claim => claim == "S" || claim == "H").WithMessage("Claim must either be 'S' or 'H'!");
            RuleFor(booking => booking.ExchangeRage).Must(rate => rate == null || rate > 0).WithMessage("ExchangeRate must be NULL or > 0!");
            RuleFor(booking => booking.BasicVolume)
                .Must(bv => bv == null || (bv > 0 && bv < 9999999999.99m))
                .WithMessage("BasicVolume must be NULL OR >0 and <max!");
            RuleFor(booking => booking)
                .Must(booking => booking.BasicVolumeCurrencySymbol == null || booking.BasicVolume.HasValue)
                .WithMessage("If BasicVolumeCurrencySymbol is used, BasicVolume can not be NULL!");
            RuleFor(booking => booking.AccountNumber).Length(impersonalAccountsLength, impersonalAccountsLength + 1).NotNull();
            RuleFor(booking => booking.ContraAccountNumber).Length(impersonalAccountsLength, impersonalAccountsLength + 1).NotNull();
            RuleFor(booking => booking)
                .Must(b => b.AccountNumber.Length + b.ContraAccountNumber.Length <= impersonalAccountsLength * 2 + 1)
                .WithMessage("Booking from one PersonalAccountNumber to another PersonalAccountNumber is forbidden!");
            RuleFor(booking => booking.TaxKey).Length(1, 4);
            RuleFor(booking => booking.Date).NotNull();
            RuleFor(booking => booking.DocumentField1).Length(0, 36);
            RuleFor(booking => booking.DocumentField2).Length(0, 12);
            RuleFor(booking => booking.CashDiscount)
                .Must(bv => bv == null || (bv > 0 && bv < 9999999999.99m))
                .WithMessage("CashDiscount must be NULL OR >0 and <max!");
            RuleFor(booking => booking.BookingText).Length(0, 60);
            RuleFor(booking => booking.DiverseAccountNumber).Length(0, 9);
            RuleFor(booking => booking.PartnerBank).Length(0, 3);
            RuleFor(booking => booking.PartnerBank).Length(0, 210);
            RuleFor(booking => booking.CashDiscountType)
                .Must(bv => bv == null || (bv > 0 && bv <= 2))
                .WithMessage("CashDiscountType must be NULL OR >0 and <max!");
            RuleFor(booking => booking.BookingType).Length(0, 2);
            RuleFor(booking => booking.PaymentType)
                .Must(bv => bv == null || (bv > 0 && bv <= 99))
                .WithMessage("PaymentType must be NULL OR >0 and <max!");
            RuleFor(booking => booking.Proprietor).Length(0, 76);
            RuleFor(booking => booking.GeneralInversion).Must(generalInversion => generalInversion == "0" || generalInversion == "1").WithMessage("General Inversion must be 0 or 1.");
            RuleFor(booking => booking.TaxRate).Must(taxRate => taxRate == null || (taxRate > 1.00 && taxRate < 999.99)).WithMessage("Taxkey must be at least 2 digits and maximum 5 digits.");
            RuleFor(booking => booking.Country).Must(country => country == null || country.Length == 2).WithMessage("Country must be null or 2 digits");
        }

        private void AddBookingInfoRules()
        {
            RuleFor(booking => booking.BookingInfoType1).Length(0, 20);
            RuleFor(booking => booking.BookingInfoContent1).Length(0, 210);
            RuleFor(booking => booking.BookingInfoType2).Length(0, 20);
            RuleFor(booking => booking.BookingInfoContent2).Length(0, 210);
            RuleFor(booking => booking.BookingInfoType3).Length(0, 20);
            RuleFor(booking => booking.BookingInfoContent3).Length(0, 210);
            RuleFor(booking => booking.BookingInfoType4).Length(0, 20);
            RuleFor(booking => booking.BookingInfoContent4).Length(0, 210);
            RuleFor(booking => booking.BookingInfoType5).Length(0, 20);
            RuleFor(booking => booking.BookingInfoContent5).Length(0, 210);
            RuleFor(booking => booking.BookingInfoType6).Length(0, 20);
            RuleFor(booking => booking.BookingInfoContent6).Length(0, 210);
            RuleFor(booking => booking.BookingInfoType7).Length(0, 20);
            RuleFor(booking => booking.BookingInfoContent7).Length(0, 210);
            RuleFor(booking => booking.BookingInfoType8).Length(0, 20);
            RuleFor(booking => booking.BookingInfoContent8).Length(0, 210);
        }

        private void AddMiscRuls()
        {
            RuleFor(booking => booking.CostCenter1).Length(0, 36);
            RuleFor(booking => booking.CostCenter2).Length(0, 36);
            RuleFor(booking => booking.CostAmount)
                .Must(bv => bv == null || (bv > 0 && bv < 999999999999.9999m))
                .WithMessage("CostAmount must be NULL OR >0 and <max!");
            RuleFor(booking => booking.CountryCodeAndTaxId).Length(0, 15);
            RuleFor(booking => booking.EuroTax)
                .Must(bv => bv == null || (bv > 0 && bv < 99.99m))
                .WithMessage("EuroTax must be NULL OR >0 and <max!");
            RuleFor(booking => booking.DifferentTaxType).Length(0, 1);
            RuleFor(booking => booking.IntentionLL)
                .Must(bv => bv == null || (bv > 0 && bv <= 999))
                .WithMessage("IntentionLL must be NULL OR >0 and <=max!");
            RuleFor(booking => booking.FunctionLL)
                .Must(bv => bv == null || (bv > 0 && bv <= 999))
                .WithMessage("FunctionLL must be NULL OR >0 and <=max!");
            RuleFor(booking => booking.BU49FunctionType)
                .Must(bv => bv == null || (bv > 0 && bv <= 9))
                .WithMessage("BU49FunctionType must be NULL OR >0 and <=max!");
            RuleFor(booking => booking.BU49FunctionNumber)
                .Must(bv => bv == null || (bv > 0 && bv <= 99))
                .WithMessage("BU49FunctionNumber must be NULL OR >0 and <=max!");
            RuleFor(booking => booking.BU49FunctionAddition)
                .Must(bv => bv == null || (bv > 0 && bv <= 999))
                .WithMessage("BU49FunctionAddition must be NULL OR >0 and <=max!");
            RuleFor(booking => booking.Amount)
                .Must(bv => bv == null || (bv > 0 && bv <= 99999999))
                .WithMessage("Amount must be NULL OR >0 and <=max!");
            RuleFor(booking => booking.Weight)
                .Must(bv => bv == null || (bv > 0 && bv <= 99999999.99m))
                .WithMessage("Weight must be NULL OR >0 and <=max!");
            RuleFor(booking => booking.ClaimType).Length(0, 10);
            RuleFor(booking => booking.OrderNumber).Length(0, 30);
            RuleFor(booking => booking.TaxKeyPrepayment)
                .Must(bv => bv == null || (bv > 0 && bv <= 99))
                .WithMessage("TaxKeyPrepayment must be NULL OR >0 and <=max!");
            RuleFor(booking => booking.CountryCodePrePayment).Length(0, 2);
            RuleFor(booking => booking.IntentionLLPrepayment)
                .Must(bv => bv == null || (bv > 0 && bv <= 999))
                .WithMessage("IntentionLLPrepayment must be NULL OR >0 and <=max!");
            RuleFor(booking => booking.EuroTaxPrepayment)
                .Must(bv => bv == null || (bv > 0 && bv < 99.99m))
                .WithMessage("EuroTaxPrepayment must be NULL OR >0 and <max!");
            RuleFor(booking => booking.SepaReference).Length(0, 35);
            RuleFor(booking => booking.ParticipantNumber)
                .Must(bv => bv == null || (bv > 0 && bv < 9999))
                .WithMessage("ParticipantNumber must be NULL OR >0 and <max!");
            RuleFor(booking => booking.IdentificationNumber).Length(0, 11);
            RuleFor(booking => booking.PainterNumber).Length(0, 20);
            RuleFor(booking => booking.SoBilIntention).Length(0, 30);
            RuleFor(booking => booking.SoBilKey)
                .Must(bv => bv == null || (bv > 0 && bv < 99))
                .WithMessage("SoBilKey must be NULL OR >0 and <max!");
        }

        private void AddAdditionInfoRules()
        {
            RuleFor(booking => booking.AdditionalInfoType1).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent1).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType2).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent2).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType3).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent3).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType4).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent4).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType5).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent5).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType6).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent6).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType7).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent7).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType8).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent8).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType9).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent9).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType10).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent10).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType11).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent11).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType12).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent12).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType13).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent13).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType14).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent14).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType15).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent15).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType16).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent16).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType17).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent17).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType18).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent18).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType19).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent19).Length(0, 210);
            RuleFor(booking => booking.AdditionalInfoType20).Length(0, 20);
            RuleFor(booking => booking.AdditionalInfoContent20).Length(0, 210);
        }

        /// <summary>   Validates the specified instance. </summary>
        ///
        /// <param name="instance"> The instance to validate. </param>
        ///
        /// <returns>   A ValidationResult object containing any validation failures. </returns>
        public ValidationResult Validate(IDatevRow instance)
        {
            return base.Validate(instance as BookingRow);
        }

        /// <summary>   Validate the specified instance asynchronously. </summary>
        ///
        /// <param name="instance">     The instance to validate. </param>
        /// <param name="cancellation"> The cancellation. </param>
        ///
        /// <returns>   A ValidationResult object containing any validation failures. </returns>
	    public Task<ValidationResult> ValidateAsync(IDatevRow instance, CancellationToken cancellation = new CancellationToken())
        {
            return base.ValidateAsync(instance as BookingRow, cancellation);
        }
    }
}
