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
    public class AccountsController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            CrmConnection crmConnection = new CrmConnection();
            return crmConnection.CrmRequestWithParametr("accounts");
        }
    }
}
