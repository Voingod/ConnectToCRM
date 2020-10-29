using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConnectToCRM.Helpers;
using ConnectToCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ConnectToCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AccountsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            CrmConnection crmConnection = new CrmConnection(_config);
            var accounts = await crmConnection.CrmRequestWithParametr("accounts");
            var result = JsonConvert.DeserializeObject<DynamicsEntityCollection<AccountsModel>>(accounts);

            return Ok(result);
        }
    }
}
