using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Http.OData;
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
        private readonly CrmService _contact;

        public ContactsController(CrmService contact)
        {
            _contact = contact;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string firstName, string sortOrder = "createdon", string sortType = "asc", int page = 1, int pageSize = 3, int top = 10)
        {
            //string url = !String.IsNullOrEmpty(firstName) ?
            //    "contacts?$filter=contains(firstname,'" + firstName + "')&$orderby= " + sortOrder + " " + sortType :
            //    "contacts?$top=" + top + "&$orderby=" + sortOrder + " " + sortType;

            string fetchXml = @"<fetch count='2' page='1' >
  < entity name = 'contact' >
 
     < attribute name = 'firstname' />
  
    </ entity >
  </ fetch > ";

            string url = "contacts?fetchXml="+ fetchXml;

            var contacts = await _contact.Request<ContactsModel>(HttpMethod.Get, url);
            //var someContacts = contacts.Value.Skip((page - 1) * pageSize).Take(pageSize);
            //SortModel sortTest = new SortModel();
            //var sorted = sortTest.Sort(sortOrder, someContacts);
            //if (!String.IsNullOrEmpty(firstName))
            //{
            //    return Ok(sorted.Where(n => n.FirstName == firstName));
            //}
            return Ok(contacts);
        }

        [HttpPost]
        public async void Post()
        {
            ContactsModel contactsModel = new ContactsModel { FirstName = "Test", LastName = "November" };
            await _contact.Request(HttpMethod.Post, "contacts", contactsModel);
        }
    }
}
