using Newtonsoft.Json;
using System;

namespace Sbanken.DotNet.Models.Response.Bank
{
    public class CardDetails
    {
        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }

        [JsonProperty("currencyAmount")]
        public decimal CurrencyAmount { get; set; }

        [JsonProperty("currencyRate")]
        public decimal CurrencyRate { get; set; }

        [JsonProperty("merchantCategoryCode")]
        public string MerchantCategoryCode { get; set; }

        [JsonProperty("merchantCategoryDescription")]
        public string MerchantCategoryDescription { get; set; }

        [JsonProperty("merchantCity")]
        public string MerchantCity { get; set; }

        [JsonProperty("merchantName")]
        public string MerchantName { get; set; }

        [JsonProperty("originalCurrencyCode")]
        public string OriginalCurrencyCode { get; set; }

        [JsonProperty("purchaseDate")]
        public DateTime? PurchaseDate { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }
    }
}