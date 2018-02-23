using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sbanken.DotNet.Models.Response.Customers
{
    public class Customer
    {
        [JsonProperty("customerId")]
        public string CustomerId { get; protected set; }

        [JsonProperty("firstName")]
        public string FirstName { get; protected set; }

        [JsonProperty("lastName")]
        public string LastName { get; protected set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; protected set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; protected set; }

        [JsonProperty("postalAddress")]
        public Address PostalAddress { get; protected set; }

        [JsonProperty("streetAddress")]
        public Address StreetAddress { get; protected set; }

        [JsonProperty("phoneNumbers")]
        public IReadOnlyList<PhoneNumber> PhoneNumbers { get; protected set; }
    }
}