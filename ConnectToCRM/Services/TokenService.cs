using ConnectToCRM.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToCRM.Services
{
    public class TokenService
    {

        private readonly CrmConfiguration _crmConfiguration;

        public TokenService(IOptions<CrmConfiguration> crmConfiguration)
        {
            _crmConfiguration = crmConfiguration.Value;
        }

        private AuthenticationResult accessToken;
        public async Task<AuthenticationResult> GenerateToken()
        {
            if (accessToken == null|| accessToken.ExpiresOn <= DateTime.UtcNow)
            {
                accessToken = await AccessTokenGenerator(_crmConfiguration.ClientId, _crmConfiguration.ClientSecret,
                                             _crmConfiguration.TenantID, _crmConfiguration.CrmUrl);
            }
            return accessToken;
        }
        private async Task<AuthenticationResult> AccessTokenGenerator(string clientId, string clientSecret, string tenantID, string requestUri)
        {
            string authority = "https://login.microsoftonline.com/" + tenantID;
            var credentials = new ClientCredential(clientId, clientSecret);
            var authContext = new AuthenticationContext(authority);
            var result = await authContext.AcquireTokenAsync(requestUri.Remove(requestUri.IndexOf("api")), credentials);
            return result;
        }
    }
}
