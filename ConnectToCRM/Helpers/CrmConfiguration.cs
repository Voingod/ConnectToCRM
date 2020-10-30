using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToCRM.Helpers
{
    public class CrmConfiguration
    {
        public string CrmUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TenantID { get; set; }
    }
}
