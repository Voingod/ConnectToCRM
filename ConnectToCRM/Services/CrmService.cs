using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ConnectToCRM.Helpers;
using ConnectToCRM.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ConnectToCRM.Controllers
{
    public class CrmService
    {

        private readonly CrmConfiguration _crmConfiguration;

        public CrmService(IOptions<CrmConfiguration> crmConfiguration)
        {
            _crmConfiguration = crmConfiguration.Value;
        }

        public async Task<DynamicsEntityCollection<T>> Request<T>(HttpMethod httpMethod, string entityName, T body = null) where T : class
        {
            CrmConnection crmConnection = new CrmConnection(_crmConfiguration);
            var contacts = await crmConnection.CrmRequest(httpMethod, entityName, body);
            var qwe = contacts.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<DynamicsEntityCollection<T>>(qwe);
            return result;
        }
    }


}
