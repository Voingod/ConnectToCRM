using ConnectToCRM.Controllers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToCRM.Helpers
{
    public class CrmConnection
    {
        private async Task<string> AccessTokenGenerator(string clientId, string clientSecret, string tenantID, string requestUri)
        {
            string authority = "https://login.microsoftonline.com/" + tenantID;
            var credentials = new ClientCredential(clientId, clientSecret);
            var authContext = new AuthenticationContext(authority);
            var result = await authContext.AcquireTokenAsync(requestUri.Remove(requestUri.IndexOf("api")), credentials);
            return result.AccessToken;
        }

        private async Task<HttpResponseMessage> CrmRequest(HttpMethod httpMethod, string requestUri, string clientId,
                                                                 string clientSecret, string tenantID, string body = null)
        {
            // Acquiring Access Token  
            var accessToken = await AccessTokenGenerator(clientId, clientSecret, tenantID, requestUri);

            var client = new HttpClient();
            var message = new HttpRequestMessage(httpMethod, requestUri);

            //// OData related headers  
            //message.Headers.Add("OData-MaxVersion", "4.0");
            //message.Headers.Add("OData-Version", "4.0");
            //message.Headers.Add("Prefer", "odata.include-annotations=\"*\"");

            // Passing AccessToken in Authentication header  
            message.Headers.Add("Authorization", $"Bearer {accessToken}");

            // Adding body content in HTTP request   
            if (body != null)
                message.Content = new StringContent(body, Encoding.UTF8, "application/json");

            return await client.SendAsync(message);
        }

        public string CrmRequestWithParametr(string entity)
        {           
            var accounts = CrmRequest(
                httpMethod: HttpMethod.Get,
                ParametrsToConnect.crmUrl + entity,
                ParametrsToConnect.clientId,
                ParametrsToConnect.clientSecret,
                ParametrsToConnect.tenantID)
                .Result.Content.ReadAsStringAsync();
            return accounts.Result;
        }
    }
}
