using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ConnectToCRM.Helpers;
using ConnectToCRM.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ConnectToCRM.Controllers
{
    public class CrmService
    {
        private readonly IConfiguration _config;

        public CrmService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<DynamicsEntityCollection<T>> Request<T>(HttpMethod httpMethod, string entityName, T body = null) where T : class
        {
            CrmConnection crmConnection = new CrmConnection(_config);
            var contacts = await crmConnection.CrmRequest(httpMethod, entityName, body);
            var qwe = contacts.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<DynamicsEntityCollection<T>>(qwe);
            return result;
        }
    }


}
