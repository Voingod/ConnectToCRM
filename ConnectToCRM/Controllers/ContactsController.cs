using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConnectToCRM.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConnectToCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            CrmConnection crmConnection = new CrmConnection();
            var contacts = crmConnection.CrmRequest(
                httpMethod: HttpMethod.Get,
                "https://udstrialsdemo40.crm4.dynamics.com/api/data/v9.1/contacts",
                clientId: "00aea9ee-9733-41d2-b1c7-b2d2207fb471",
                clientSecret: "9wPio6.2O9PPE~TG5-8xA9S-usAHFA~ZL2",
                tenantID: "29a54688-cd45-4308-9b73-435d36ddb378")
                .Result.Content.ReadAsStringAsync();
            // Similarly you can make POST, PATCH & DELETE requests 
            return contacts.Result;
        }
    }
}
