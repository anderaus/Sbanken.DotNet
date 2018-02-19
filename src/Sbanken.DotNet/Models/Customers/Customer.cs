using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sbanken.DotNet.Models.Customers
{
    public class Customer
    {
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("postalAddress")]
        public Address PostalAddress { get; set; }

        [JsonProperty("streetAddress")]
        public Address StreetAddress { get; set; }

        [JsonProperty("phoneNumbers")]
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
    }
}