using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConnectToCRM.Models
{
    public class AccountsModel
    {
        [JsonProperty(PropertyName = "createdon")]
        public string CreatedOn { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string AccountName { get; set; }
        
        [JsonProperty(PropertyName = "accountnumber")]
        public int AccountNumber { get; set; }
        
        [JsonProperty(PropertyName = "telephone1")]
        public string Phone { get; set; }

        
    }
}
