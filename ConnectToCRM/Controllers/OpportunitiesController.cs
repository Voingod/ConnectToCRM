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
    public class OpportunitiesController : ControllerBase
    {
        private readonly CrmService _opportunity;

        public OpportunitiesController(CrmService opportunity)
        {
            _opportunity = opportunity;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string opportunityName, string sortOrder = "createdon", string sortType = "asc", int page = 1, int pageSize = 3)
        {
            string fetchXml = "<fetch mapping='logical' count='" + pageSize + "' page='" + page + "'>" +
   "<entity name='opportunity'> " +
      "<attribute name = 'createdon'/> " +
      "<attribute name = 'name' /> " +
      "<attribute name = 'purchaseprocess' /> " +
      "<attribute name = 'msdyn_forecastcategory' /> " +
    "</entity> " +
    "</fetch>";
 
            string url = !String.IsNullOrEmpty(opportunityName) ?
    "opportunities?fetchXml=" + fetchXml + "&$filter=contains(name,'" + opportunityName + "')&$orderby= " + sortOrder + " " + sortType :
    "opportunities?fetchXml=" + fetchXml + "&$orderby=" + sortOrder + " " + sortType;

            var Opportunities = await _opportunity.Request<OpportunitiesModel>(HttpMethod.Get, url);
            return Ok(Opportunities);
        }

        [HttpPost]
        public async void Post(OpportunitiesModel OpportunitiesModel)
        {
            await _opportunity.Request(HttpMethod.Post, "Opportunities", OpportunitiesModel);
        }
    }
}
