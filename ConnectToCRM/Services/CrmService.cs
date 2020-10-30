using System.Net;
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

        public async Task<DynamicsEntityCollection<ContactsModel>> GetAllRecords(string entityName)
        {
            CrmConnection crmConnection = new CrmConnection(_config);
            var contacts = await crmConnection.CrmRequestWithParametr(entityName);
            var result = JsonConvert.DeserializeObject<DynamicsEntityCollection<ContactsModel>>(contacts);
            return result;
        }

        public async Task<HttpStatusCode> CreateRecord<T>(string entityName, T model)
        {
            CrmConnection crmConnection = new CrmConnection(_config);
            var response = await crmConnection.CrmRequestToCreatePost(entityName, model);
            return response;
        }
    }


}
