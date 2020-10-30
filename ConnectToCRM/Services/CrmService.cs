using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConnectToCRM.Helpers;
using ConnectToCRM.Models;
using ConnectToCRM.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ConnectToCRM.Controllers
{
    public class CrmService
    {

        private readonly CrmConfiguration _crmConfiguration;
        private readonly TokenService _tokenService;
        public CrmService(IOptions<CrmConfiguration> crmConfiguration, TokenService tokenService)
        {
            _crmConfiguration = crmConfiguration.Value;
            _tokenService = tokenService;
        }

        public async Task<DynamicsEntityCollection<T>> Request<T>(HttpMethod httpMethod, string entityName, T body = null) where T : class
        {
            var token = _tokenService.GenerateToken();
            var client = new HttpClient();
            var message = new HttpRequestMessage(httpMethod, _crmConfiguration.CrmUrl + entityName);
            // Passing AccessToken in Authentication header  
            message.Headers.Add("Authorization", $"Bearer {token.Result.AccessToken}");

            // Adding body content in HTTP request   
            if (body != null)
                message.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(message);
            var contacts = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<DynamicsEntityCollection<T>>(contacts);

            return result;
        }
    }


}
