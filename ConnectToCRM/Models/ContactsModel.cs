using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConnectToCRM.Models
{

    public class ContactsModel
    {
        [JsonPropertyName("customertypecode")]
        public int CustomerTypeCode { get; set; }

        [JsonPropertyName("address1_addressid")]
        public string Address1AddressId { get; set; }

        [JsonPropertyName("address2_addressid")]
        public string Address2AddressId { get; set; }

        [JsonPropertyName("address3_addressid")]
        public string Address3AddressId { get; set; }

        [JsonPropertyName("contactid")]
        public string ContactId { get; set; }

        [JsonPropertyName("createdon")]
        public string CreatedOn { get; set; }

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("statecode")]
        public int StateCode { get; set; }

        [JsonPropertyName("statuscode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("emailaddress1")]
        public string EmailAddress { get; set; }
    }
}
