using Newtonsoft.Json;

namespace VerifonePayment.Lib.Models
{
    public class Receipt
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
        public object OriginalImage { get; set; }

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
}
