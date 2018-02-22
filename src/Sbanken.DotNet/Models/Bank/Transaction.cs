using Newtonsoft.Json;
using System;

namespace Sbanken.DotNet.Models.Bank
{
    public class Transaction
    {
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("otherAccountNumber")]
        public string OtherAccountNumber { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("transactionType")]
        public string TransactionType { get; set; }

        [JsonProperty("registrationDate")]
        public DateTime? RegistrationDate { get; set; }

        [JsonProperty("accountingDate")]
        public DateTime? AccountingDate { get; set; }

        [JsonProperty("interestDate")]
        public DateTime? InterestDate { get; set; }
    }
}