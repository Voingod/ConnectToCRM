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
        //[JsonPropertyName("customertypecode")]
        //public string Address1Addressid { get; set; }
        //[JsonPropertyName("customertypecode")]
        //public string Address2Addressid { get; set; }
        //[JsonPropertyName("customertypecode")]
        //public string Address3Addressid { get; set; }
        //[JsonPropertyName("customertypecode")]
        //public string Contactid { get; set; }
        //[JsonPropertyName("customertypecode")]
        //public string Createdon { get; set; }
        //[JsonPropertyName("customertypecode")]
        //public string Firstname { get; set; }
        //[JsonPropertyName("customertypecode")]
        //public string Lastname { get; set; }
        //[JsonPropertyName("customertypecode")]
        //public int Statecode { get; set; }
        //[JsonPropertyName("customertypecode")]
        //public int Statuscode { get; set; }
    }
}
