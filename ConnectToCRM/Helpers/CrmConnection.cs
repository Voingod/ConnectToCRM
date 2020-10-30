using ConnectToCRM.Controllers;
using ConnectToCRM.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToCRM.Helpers
{
    public class CrmConnection
    {

        private readonly IConfiguration _config;

        public CrmConnection(IConfiguration config)
        {
            _config = config;
        }


        private async Task<string> AccessTokenGenerator(string clientId, string clientSecret, string tenantID, string requestUri)
        {
            string authority = "https://login.microsoftonline.com/" + tenantID;
            var credentials = new ClientCredential(clientId, clientSecret);
            var authContext = new AuthenticationContext(authority);
            var result = await authContext.AcquireTokenAsync(requestUri.Remove(requestUri.IndexOf("api")), credentials);
            return result.AccessToken;
        }

        public async Task<HttpResponseMessage> CrmRequest<T>(HttpMethod httpMethod, string entityName, T body = null) where T : class
        {
            string crmUrl = _config.GetValue<string>("crmUrl");
            string clientId = _config.GetValue<string>("clientId");
            string clientSecret = _config.GetValue<string>("clientSecret");
            string tenantID = _config.GetValue<string>("tenantID");

            // Acquiring Access Token  
            var accessToken = await AccessTokenGenerator(clientId, clientSecret, tenantID, crmUrl);

            var client = new HttpClient();
            var message = new HttpRequestMessage(httpMethod, crmUrl + entityName);

            // Passing AccessToken in Authentication header  
            message.Headers.Add("Authorization", $"Bearer {accessToken}");

            // Adding body content in HTTP request   
            if (body != null)
                message.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            return await client.SendAsync(message);
        }

    }
}
