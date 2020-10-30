using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ConnectToCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace ConnectToCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly CrmService _test;

        public ContactsController(CrmService test)
        {
            _test = test;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            var contacts = await _test.GetAllRecords("contacts");
            return Ok(contacts);
        }

        [HttpPost]
        public async void Post(ContactsModel contactsModel)
        {                
            await _test.CreateRecord("contacts", contactsModel);
        }

    }

}
