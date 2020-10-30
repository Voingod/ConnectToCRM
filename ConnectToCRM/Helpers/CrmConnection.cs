using ConnectToCRM.Controllers;
using ConnectToCRM.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly CrmConfiguration _crmConfiguration;

        public CrmConnection(CrmConfiguration crmConfiguration)
        {
            _crmConfiguration = crmConfiguration;
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
            // Acquiring Access Token  
            var accessToken = await AccessTokenGenerator(_crmConfiguration.ClientId, _crmConfiguration.ClientSecret, 
                                                         _crmConfiguration.TenantID, _crmConfiguration.CrmUrl);

            var client = new HttpClient();
            var message = new HttpRequestMessage(httpMethod, _crmConfiguration.CrmUrl + entityName);

            // Passing AccessToken in Authentication header  
            message.Headers.Add("Authorization", $"Bearer {accessToken}");

            // Adding body content in HTTP request   
            if (body != null)
                message.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            return await client.SendAsync(message);
        }

    }
}
