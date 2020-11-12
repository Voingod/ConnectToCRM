using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConnectToCRM.Models
{

    public class ContactsModel
    {
        private void SetDefaultProperty()
        {
            CustomerTypeCode = 1;
            StateCode = 0;
            StatusCode = 1;
            ContactId = Guid.NewGuid().ToString();
            Address1AddressId = Guid.NewGuid().ToString();
            Address2AddressId = Guid.NewGuid().ToString();
            Address3AddressId = Guid.NewGuid().ToString();
            if (EmailAddress == null)
            {
                EmailAddress = "";
            }
        }
        public void CheckProperies(ContactsModel contactsModel)
        {
            contactsModel.Address1AddressId = contactsModel.Address1AddressId == null ? Address1AddressId : contactsModel.Address1AddressId;
            contactsModel.Address2AddressId = contactsModel.Address2AddressId == null ? Address2AddressId : contactsModel.Address2AddressId;
            contactsModel.Address3AddressId = contactsModel.Address3AddressId == null ? Address3AddressId : contactsModel.Address3AddressId;
            contactsModel.ContactId = contactsModel.ContactId == null ? ContactId : contactsModel.ContactId;
            contactsModel.CreatedOn = contactsModel.CreatedOn == null ? CreatedOn : contactsModel.CreatedOn;
            contactsModel.CustomerTypeCode = contactsModel.CustomerTypeCode == 0 ? CustomerTypeCode : contactsModel.CustomerTypeCode;
            contactsModel.EmailAddress = contactsModel.EmailAddress == null ? EmailAddress : contactsModel.EmailAddress;
            contactsModel.FirstName = contactsModel.FirstName == null ? FirstName : contactsModel.FirstName;
            contactsModel.LastName = contactsModel.LastName == null ? LastName : contactsModel.LastName;
            contactsModel.StateCode = contactsModel.StateCode == 1 ? StateCode : contactsModel.StateCode;
            contactsModel.StatusCode = contactsModel.StatusCode == 0 ? StatusCode : contactsModel.StatusCode;
        }

        public async void SetDefaultPropertyAsync() => await Task.Run(() => SetDefaultProperty());

        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "customertypecode")]
        public int CustomerTypeCode { get; set; }

        [JsonProperty(PropertyName = "address1_addressid")]
        public string Address1AddressId { get; set; }

        [JsonProperty(PropertyName = "address2_addressid")]
        public string Address2AddressId { get; set; }

        [JsonProperty(PropertyName = "address3_addressid")]
        public string Address3AddressId { get; set; }

        [JsonProperty(PropertyName = "contactid")]
        public string ContactId { get; set; }

        [JsonProperty(PropertyName = "createdon")]
        public string CreatedOn { get; set; }

        [JsonProperty(PropertyName = "statecode")]
        public int StateCode { get; set; }

        [JsonProperty(PropertyName = "statuscode")]
        public int StatusCode { get; set; }

        [JsonProperty(PropertyName = "emailaddress1")]
        public string EmailAddress { get; set; }

        //[JsonProperty(PropertyName = "@odata.nextLink")]
        //public string NextLink { get; set; }

    }
}
