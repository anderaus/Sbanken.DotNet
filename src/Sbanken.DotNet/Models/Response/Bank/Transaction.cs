using Newtonsoft.Json;
using System;

namespace Sbanken.DotNet.Models.Response.Bank
{
    public class Transaction
    {
        [JsonProperty("transactionId")]
        public string TransactionId { get; protected set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; protected set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; protected set; }

        [JsonProperty("otherAccountNumber")]
        public string OtherAccountNumber { get; protected set; }

        [JsonProperty("amount")]
        public decimal Amount { get; protected set; }

        [JsonProperty("text")]
        public string Text { get; protected set; }

        [JsonProperty("transactionType")]
        public string TransactionType { get; protected set; }

        [JsonProperty("registrationDate")]
        public DateTime? RegistrationDate { get; protected set; }

        [JsonProperty("accountingDate")]
        public DateTime? AccountingDate { get; protected set; }

        [JsonProperty("interestDate")]
        public DateTime? InterestDate { get; protected set; }
    }
}