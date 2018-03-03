using Newtonsoft.Json;
using System;

namespace Sbanken.DotNet.Models.Response.Bank
{
    public class Transaction
    {
        [JsonProperty("accountingDate")]
        public DateTime? AccountingDate { get; set; }

        [JsonProperty("interestDate")]
        public DateTime? InterestDate { get; set; }

        [JsonProperty("otherAccountNumber")]
        public string OtherAccountNumber { get; set; }

        [JsonProperty("otherAccountNumberSpecified")]
        public bool OtherAccountNumberSpecified { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("transactionType")]
        public string TransactionType { get; set; }

        [JsonProperty("transactionTypeCode")]
        public int TransactionTypeCode { get; set; }

        [JsonProperty("transactionTypeText")]
        public string TransactionTypeText { get; set; }

        [JsonProperty("isReservation")]
        public bool IsReservation { get; set; }

        [JsonProperty("reservationType")]
        public string ReservationType { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("cardDetails")]
        public CardDetails CardDetails { get; set; }

        [JsonProperty("cardDetailsSpecified")]
        public bool CardDetailsSpecified { get; set; }
    }
}