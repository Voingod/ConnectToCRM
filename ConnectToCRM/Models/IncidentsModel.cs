using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConnectToCRM.Models
{
    public class IncidentsModel
    {
        [JsonPropertyName("createdon")]
        public string CreatedOn { get; set; }
    }
}
