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
        public async Task<string> Get()
        {
            CrmConnection crmConnection = new CrmConnection();
            return await crmConnection.CrmRequestWithParametr("contacts");
        }
    }
}
