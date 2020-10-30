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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        public async Task<IActionResult> Get(int page = 1, int pageSize = 3)
        {
            var contacts = await _test.Request<ContactsModel>(HttpMethod.Get,"contacts");
            var someContacts = contacts.Value.Skip((page - 1) * pageSize).Take(pageSize);
            return Ok(someContacts);
        }

        [HttpGet("{filterByName}")]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromQuery] string firstName)
        {
            var contacts = await _test.Request<ContactsModel>(HttpMethod.Get,"contacts");
            return Ok(contacts.Value.Where(c => c.FirstName == firstName));
        }

        [HttpPost]
        public async void Post(ContactsModel contactsModel)
        {
            await _test.Request(HttpMethod.Post, "contacts", contactsModel);
        }
    }
}
