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
    public class IncidentsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public IncidentsController(IConfiguration config)
        {
            _config = config;
        }

        //[HttpGet]
        //[Produces("application/json")]
        //public async Task<IActionResult> Get()
        //{
        //    CrmConnection crmConnection = new CrmConnection(_config);
        //    var incidents = await crmConnection.CrmRequestWithParametr("incidents");
        //    var result = JsonConvert.DeserializeObject<DynamicsEntityCollection<IncidentsModel>>(incidents);

        //    return Ok(result);
        //}
    }
}
