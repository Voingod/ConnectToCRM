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
        public async Task<IActionResult> Get(string firstName, string sortOrder = "createdon", string sortType = "asc", int page = 1, int pageSize = 3)
        {
            string fetchXml = "<fetch mapping='logical' count='"+ pageSize + "' page='"+ page + "'>"+
   "<entity name='contact'> "+
      "<attribute name = 'contactid'/> "+
      "<attribute name = 'firstname' /> "+
      "<attribute name = 'lastname' /> "+
      "<attribute name = 'customertypecode' /> "+
      "<attribute name = 'address1_addressid' /> "+
      "<attribute name = 'address2_addressid' /> "+
      "<attribute name = 'address3_addressid' /> "+
      "<attribute name = 'createdon' /> "+
      "<attribute name = 'statecode' /> "+
      "<attribute name = 'statuscode' /> "+
      "<attribute name = 'emailaddress1' /> "+
    "</entity> "+
    "</fetch>";

            string url = !String.IsNullOrEmpty(firstName) ?
    "contacts?fetchXml="+ fetchXml + "&$filter=contains(firstname,'" + firstName + "')&$orderby= " + sortOrder + " " + sortType :
    "contacts?fetchXml=" + fetchXml + "&$orderby=" + sortOrder + " " + sortType;

            var contacts = await _contact.Request<ContactsModel>(HttpMethod.Get, url);
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
