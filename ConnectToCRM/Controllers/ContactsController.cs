using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ConnectToCRM.Helpers;
using ConnectToCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConnectToCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ContactsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            CrmConnection crmConnection = new CrmConnection(_config);
            var contacts = await crmConnection.CrmRequestWithParametr("contacts");
            var result = JsonConvert.DeserializeObject<DynamicsEntityCollection<ContactsModel>>(contacts);
            return Ok(result);
        }
    }


}
