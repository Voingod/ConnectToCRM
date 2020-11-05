using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConnectToCRM.Models
{
    public class IncidentsModel
    {
        [JsonProperty(PropertyName = "createdon")]
        public string CreatedOn { get; set; }
        
        [JsonProperty(PropertyName = "createdon")]
        public string CaseTitle { get; set; }
        
        [JsonProperty(PropertyName = "createdon")]
        public string ID { get; set; }
        
        [JsonProperty(PropertyName = "createdon")]
        public string Origin { get; set; }
    
    
    }
}
