using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConnectToCRM.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConnectToCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public IncidentsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            CrmConnection crmConnection = new CrmConnection(_config);
            return await crmConnection.CrmRequestWithParametr("incidents");
        }
    }
}
