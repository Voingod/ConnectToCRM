using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConnectToCRM.Models
{
    public class OpportunitiesModel
    {
        [JsonProperty(PropertyName = "createdon")]
        public string CreatedOn { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Topic { get; set; }
        
        [JsonProperty(PropertyName = "purchaseprocess")]
        public string PurchaseProcess { get; set; }
        
        [JsonProperty(PropertyName = "msdyn_forecastcategory")]
        public string ForecastCategory { get; set; }
    }
}
