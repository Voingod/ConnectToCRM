using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly Test _test;

        public ContactsController(IConfiguration config, Test test)
        {
            _test = test;
            _config = config;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            var tt = await _test.Get();
            //CrmConnection crmConnection = new CrmConnection(_config);
            //var contacts = await crmConnection.CrmRequestWithParametr("contacts");
            //var result = JsonConvert.DeserializeObject<DynamicsEntityCollection<ContactsModel>>(contacts);

            return Ok(tt);
        }

        [HttpPost]
        public async void Post(ContactsModel model)
        {
            CrmConnection crmConnection = new CrmConnection(_config);
            await crmConnection.CrmRequestToCreatePost("contacts", model);
        }

    }
    public class Test
    {
        private readonly IConfiguration _config;

        public Test(IConfiguration config)
        {
            _config = config;
        }

        public async Task<DynamicsEntityCollection<ContactsModel>> Get()
        {
            CrmConnection crmConnection = new CrmConnection(_config);
            var contacts = await crmConnection.CrmRequestWithParametr("contacts");
            var result = JsonConvert.DeserializeObject<DynamicsEntityCollection<ContactsModel>>(contacts);

            return result;
        }
    }


}
