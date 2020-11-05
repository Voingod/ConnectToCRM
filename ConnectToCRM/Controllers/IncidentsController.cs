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
        private readonly CrmService _incident;

        public IncidentsController(CrmService incident)
        {
            _incident = incident;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string incidentName, string sortOrder = "createdon", string sortType = "asc", int page = 1, int pageSize = 3)
        {
            string fetchXml = "<fetch mapping='logical' count='" + pageSize + "' page='" + page + "'>" +
   "<entity name='incident'> " +
      "<attribute name = 'createdon'/> " +
      "<attribute name = 'name' /> " +
      "<attribute name = 'incidentnumber' /> " +
      "<attribute name = 'telephone1' /> " +
    "</entity> " +
    "</fetch>";

            string url = !String.IsNullOrEmpty(incidentName) ?
    "incidents?fetchXml=" + fetchXml + "&$filter=contains(name,'" + incidentName + "')&$orderby= " + sortOrder + " " + sortType :
    "incidents?fetchXml=" + fetchXml + "&$orderby=" + sortOrder + " " + sortType;

            var incidents = await _incident.Request<IncidentsModel>(HttpMethod.Get, url);
            return Ok(incidents);
        }

        [HttpPost]
        public async void Post(IncidentsModel incidentsModel)
        {
            await _incident.Request(HttpMethod.Post, "incidents", incidentsModel);
        }
    }
}
