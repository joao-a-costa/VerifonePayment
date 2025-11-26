using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerifonePayment.Lib.Models
{
    public class Amounts
    {
        [JsonProperty("Total")]
        public Total Total { get; set; }

        [JsonProperty("Tax")]
        public Tax Tax { get; set; }

        [JsonProperty("Subtotal")]
        public string Subtotal { get; set; }

        [JsonProperty("IsUnset")]
        public bool IsUnset { get; set; }

        [JsonProperty("Gratuity")]
        public Gratuity Gratuity { get; set; }

        [JsonProperty("Fees")]
        public Fees Fees { get; set; }

        [JsonProperty("Donation")]
        public string Donation { get; set; }

        [JsonProperty("Cashback")]
        public Cashback Cashback { get; set; }
    }

    public class CardInformation
    {
        [JsonProperty("VasData")]
        public string VasData { get; set; }

        [JsonProperty("Tokens")]
        public string Tokens { get; set; }

        [JsonProperty("ProcessorCardNetwork")]
        public string ProcessorCardNetwork { get; set; }

        [JsonProperty("PreviousBalance")]
        public string PreviousBalance { get; set; }

        [JsonProperty("PresentationMethod")]
        public int PresentationMethod { get; set; }

        [JsonProperty("PinBypassed")]
        public string PinBypassed { get; set; }

        [JsonProperty("PaymentBrand")]
        public string PaymentBrand { get; set; }

        [JsonProperty("PanLast4")]
        public string PanLast4 { get; set; }

        [JsonProperty("PanHandle")]
        public string PanHandle { get; set; }

        [JsonProperty("PanFirst2")]
        public string PanFirst2 { get; set; }

        [JsonProperty("IssuerId")]
        public string IssuerId { get; set; }

        [JsonProperty("FullVasResponse")]
        public string FullVasResponse { get; set; }

        [JsonProperty("EncryptedTracksKsn")]
        public string EncryptedTracksKsn { get; set; }

        [JsonProperty("EncryptedTracks")]
        public string EncryptedTracks { get; set; }

        [JsonProperty("EncryptedPanKsn")]
        public string EncryptedPanKsn { get; set; }

        [JsonProperty("EncryptedPan")]
        public string EncryptedPan { get; set; }

        [JsonProperty("EmvTags")]
        public EmvTags EmvTags { get; set; }

        [JsonProperty("Cvv2")]
        public string Cvv2 { get; set; }

        [JsonProperty("CardTrack3")]
        public string CardTrack3 { get; set; }

        [JsonProperty("CardTrack2")]
        public string CardTrack2 { get; set; }

        [JsonProperty("CardTrack1")]
        public string CardTrack1 { get; set; }

        [JsonProperty("CardTokenizationMethod")]
        public string CardTokenizationMethod { get; set; }

        [JsonProperty("CardToken")]
        public string CardToken { get; set; }

        [JsonProperty("CardStatus")]
        public string CardStatus { get; set; }

        [JsonProperty("CardPreferredLanguages")]
        public string CardPreferredLanguages { get; set; }

        [JsonProperty("CardPan")]
        public string CardPan { get; set; }

        [JsonProperty("CardHolderName")]
        public string CardHolderName { get; set; }

        [JsonProperty("CardExpiry")]
        public string CardExpiry { get; set; }

        [JsonProperty("CardCurrency")]
        public string CardCurrency { get; set; }

        [JsonProperty("CardCountry")]
        public string CardCountry { get; set; }

        [JsonProperty("Bin")]
        public string Bin { get; set; }

        [JsonProperty("BankUserData")]
        public string BankUserData { get; set; }

        [JsonProperty("AvailableBalance")]
        public string AvailableBalance { get; set; }

        [JsonProperty("AccountType")]
        public int AccountType { get; set; }

        [JsonProperty("AccountReference")]
        public string AccountReference { get; set; }
    }

    public class Cashback
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }

    public class CashbackAmount
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }

    public class CUSTOMER
    {
        [JsonProperty("TransactionInformation")]
        public string TransactionInformation { get; set; }

        [JsonProperty("ReceiptType")]
        public int ReceiptType { get; set; }

        [JsonProperty("QrCodeImage")]
        public string QrCodeImage { get; set; }

        [JsonProperty("PaymentInformation")]
        public string PaymentInformation { get; set; }

        [JsonProperty("OriginalImage")]
        public string OriginalImage { get; set; }

        [JsonProperty("OriginalHtml")]
        public string OriginalHtml { get; set; }

        [JsonProperty("OnlineUrl")]
        public string OnlineUrl { get; set; }

        [JsonProperty("IsQrCodeIncluded")]
        public bool IsQrCodeIncluded { get; set; }

        [JsonProperty("IsOnlineUrlIncluded")]
        public bool IsOnlineUrlIncluded { get; set; }

        [JsonProperty("IsLogoIncluded")]
        public bool IsLogoIncluded { get; set; }

        [JsonProperty("IsCashierNameIncluded")]
        public bool IsCashierNameIncluded { get; set; }

        [JsonProperty("Footer")]
        public string Footer { get; set; }

        [JsonProperty("CustomGreeting")]
        public string CustomGreeting { get; set; }

        [JsonProperty("CustomFooter")]
        public string CustomFooter { get; set; }

        [JsonProperty("CashierName")]
        public string CashierName { get; set; }

        [JsonProperty("BusinessInfo")]
        public string BusinessInfo { get; set; }

        [JsonProperty("AsPlainText")]
        public string AsPlainText { get; set; }

        [JsonProperty("AsHtml")]
        public string AsHtml { get; set; }
    }

    public class Donation
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }

    public class EmvTags
    {
        [JsonProperty("5F20")]
        public string _5F20 { get; set; }

        [JsonProperty("5F30")]
        public string _5F30 { get; set; }

        [JsonProperty("8A")]
        public string _8A { get; set; }

        [JsonProperty("5F2A")]
        public string _5F2A { get; set; }

        [JsonProperty("5F24")]
        public string _5F24 { get; set; }
    }

    public class Fees
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }

    public class FeesAmount
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }

    public class Gratuity
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }

    public class GratuityAmount
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }

    public class MERCHANT
    {
        [JsonProperty("TransactionInformation")]
        public string TransactionInformation { get; set; }

        [JsonProperty("ReceiptType")]
        public int ReceiptType { get; set; }

        [JsonProperty("QrCodeImage")]
        public string QrCodeImage { get; set; }

        [JsonProperty("PaymentInformation")]
        public string PaymentInformation { get; set; }

        [JsonProperty("OriginalImage")]
        public string OriginalImage { get; set; }

        [JsonProperty("OriginalHtml")]
        public string OriginalHtml { get; set; }

        [JsonProperty("OnlineUrl")]
        public string OnlineUrl { get; set; }

        [JsonProperty("IsQrCodeIncluded")]
        public bool IsQrCodeIncluded { get; set; }

        [JsonProperty("IsOnlineUrlIncluded")]
        public bool IsOnlineUrlIncluded { get; set; }

        [JsonProperty("IsLogoIncluded")]
        public bool IsLogoIncluded { get; set; }

        [JsonProperty("IsCashierNameIncluded")]
        public bool IsCashierNameIncluded { get; set; }

        [JsonProperty("Footer")]
        public string Footer { get; set; }

        [JsonProperty("CustomGreeting")]
        public string CustomGreeting { get; set; }

        [JsonProperty("CustomFooter")]
        public string CustomFooter { get; set; }

        [JsonProperty("CashierName")]
        public string CashierName { get; set; }

        [JsonProperty("BusinessInfo")]
        public string BusinessInfo { get; set; }

        [JsonProperty("AsPlainText")]
        public string AsPlainText { get; set; }

        [JsonProperty("AsHtml")]
        public string AsHtml { get; set; }
    }

    public class PaymentAmount
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }

    public class Receipts
    {
        [JsonProperty("MERCHANT")]
        public MERCHANT MERCHANT { get; set; }

        [JsonProperty("CUSTOMER")]
        public CUSTOMER CUSTOMER { get; set; }
    }

    public class RequestedAmounts
    {
        [JsonProperty("Total")]
        public Total Total { get; set; }

        [JsonProperty("Tax")]
        public string Tax { get; set; }

        [JsonProperty("Subtotal")]
        public string Subtotal { get; set; }

        [JsonProperty("IsUnset")]
        public bool IsUnset { get; set; }

        [JsonProperty("Gratuity")]
        public Gratuity Gratuity { get; set; }

        [JsonProperty("Fees")]
        public Fees Fees { get; set; }

        [JsonProperty("Donation")]
        public Donation Donation { get; set; }

        [JsonProperty("Cashback")]
        public Cashback Cashback { get; set; }
    }

    public class Payment
    {
        [JsonProperty("Venue")]
        public string Venue { get; set; }

        [JsonProperty("VasCommands")]
        public string VasCommands { get; set; }

        [JsonProperty("TransactionType")]
        public int TransactionType { get; set; }

        [JsonProperty("TotalsGroupId")]
        public string TotalsGroupId { get; set; }

        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("TerminalId")]
        public string TerminalId { get; set; }

        [JsonProperty("TerminalData")]
        public string TerminalData { get; set; }

        [JsonProperty("TaxAmount")]
        public TaxAmount TaxAmount { get; set; }

        [JsonProperty("StoredValueCardInformation")]
        public string StoredValueCardInformation { get; set; }

        [JsonProperty("StoredValueAction")]
        public string StoredValueAction { get; set; }

        [JsonProperty("Signature")]
        public Signature Signature { get; set; }

        [JsonProperty("SaleNote")]
        public string SaleNote { get; set; }

        [JsonProperty("RetrievalReferenceNumber")]
        public string RetrievalReferenceNumber { get; set; }

        [JsonProperty("RequestedTokenizationMethod")]
        public string RequestedTokenizationMethod { get; set; }

        [JsonProperty("RequestedTokenParameters")]
        public string RequestedTokenParameters { get; set; }

        [JsonProperty("RequestedPaymentType")]
        public string RequestedPaymentType { get; set; }

        [JsonProperty("RequestedCardPresentationMethods")]
        public List<string> RequestedCardPresentationMethods { get; set; }

        [JsonProperty("RequestedAmounts")]
        public RequestedAmounts RequestedAmounts { get; set; }

        [JsonProperty("ReferenceTimestamp")]
        public string ReferenceTimestamp { get; set; }

        [JsonProperty("ReferencePaymentId")]
        public string ReferencePaymentId { get; set; }

        [JsonProperty("ReferenceLocalPaymentId")]
        public string ReferenceLocalPaymentId { get; set; }

        [JsonProperty("RedeemedUnits")]
        public string RedeemedUnits { get; set; }

        [JsonProperty("ReconciliationId")]
        public string ReconciliationId { get; set; }

        [JsonProperty("Receipts")]
        public Receipts Receipts { get; set; }

        [JsonProperty("PaymentType")]
        public int PaymentType { get; set; }

        [JsonProperty("PaymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("PaymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("PaymentAmount")]
        public PaymentAmount PaymentAmount { get; set; }

        [JsonProperty("OrderType")]
        public int OrderType { get; set; }

        [JsonProperty("OperationsHistory")]
        public string OperationsHistory { get; set; }

        [JsonProperty("MerchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("MerchantAccount")]
        public string MerchantAccount { get; set; }

        [JsonProperty("MedicalAmounts")]
        public string MedicalAmounts { get; set; }

        [JsonProperty("MaximumCompletionAmount")]
        public string MaximumCompletionAmount { get; set; }

        [JsonProperty("LocalPaymentId")]
        public string LocalPaymentId { get; set; }

        [JsonProperty("Lane")]
        public string Lane { get; set; }

        [JsonProperty("IsStoredValueCard")]
        public bool IsStoredValueCard { get; set; }

        [JsonProperty("IsOnline")]
        public bool IsOnline { get; set; }

        [JsonProperty("IsForceOffline")]
        public string IsForceOffline { get; set; }

        [JsonProperty("IsDuplicate")]
        public bool IsDuplicate { get; set; }

        [JsonProperty("Invoice")]
        public string Invoice { get; set; }

        [JsonProperty("Installment")]
        public string Installment { get; set; }

        [JsonProperty("HostAuthCode")]
        public string HostAuthCode { get; set; }

        [JsonProperty("HasRestrictedItem")]
        public string HasRestrictedItem { get; set; }

        [JsonProperty("GratuityAmount")]
        public GratuityAmount GratuityAmount { get; set; }

        [JsonProperty("FeesAmount")]
        public FeesAmount FeesAmount { get; set; }

        [JsonProperty("ExpiryDate")]
        public string ExpiryDate { get; set; }

        [JsonProperty("EbtVoucherNum")]
        public string EbtVoucherNum { get; set; }

        [JsonProperty("DynamicCurrencyConversions")]
        public string DynamicCurrencyConversions { get; set; }

        [JsonProperty("CustomerNote")]
        public string CustomerNote { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("ContextData")]
        public string ContextData { get; set; }

        [JsonProperty("CashierName")]
        public string CashierName { get; set; }

        [JsonProperty("CashierId")]
        public string CashierId { get; set; }

        [JsonProperty("CashbackAmount")]
        public CashbackAmount CashbackAmount { get; set; }

        [JsonProperty("CardInformation")]
        public CardInformation CardInformation { get; set; }

        [JsonProperty("AuthorizationMethod")]
        public int AuthorizationMethod { get; set; }

        [JsonProperty("AuthResult")]
        public int AuthResult { get; set; }

        [JsonProperty("AuthResponseText")]
        public string AuthResponseText { get; set; }

        [JsonProperty("AuthCode")]
        public string AuthCode { get; set; }

        [JsonProperty("AppSpecificData")]
        public string AppSpecificData { get; set; }

        [JsonProperty("Amounts")]
        public Amounts Amounts { get; set; }

        [JsonProperty("AmountDue")]
        public string AmountDue { get; set; }

        [JsonProperty("AmountAvailableForRefund")]
        public string AmountAvailableForRefund { get; set; }

        [JsonProperty("AlternativePaymentId")]
        public string AlternativePaymentId { get; set; }

        [JsonProperty("AllowedPaymentOperations")]
        public List<int> AllowedPaymentOperations { get; set; }

        [JsonProperty("AdditionalAcquirerData")]
        public string AdditionalAcquirerData { get; set; }

        [JsonProperty("AcquirerResponseCode")]
        public string AcquirerResponseCode { get; set; }

        [JsonProperty("AcquirerName")]
        public string AcquirerName { get; set; }

        [JsonProperty("AcquirerId")]
        public string AcquirerId { get; set; }

        [JsonProperty("AccountType")]
        public int AccountType { get; set; }
    }

    public class Signature
    {
        [JsonProperty("Format")]
        public string Format { get; set; }

        [JsonProperty("Data")]
        public string Data { get; set; }
    }

    public class Tax
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }

    public class TaxAmount
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }

    public class Total
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Scale")]
        public int Scale { get; set; }

        [JsonProperty("DefaultPrecision")]
        public int DefaultPrecision { get; set; }
    }
}
