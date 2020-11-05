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
    public class AccountsController : ControllerBase
    {
        private readonly CrmService _account;

        public AccountsController(CrmService account)
        {
            _account = account;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string accountName, string sortOrder = "createdon", string sortType = "asc", int page = 1, int pageSize = 3)
        {
            string fetchXml = "<fetch mapping='logical' count='" + pageSize + "' page='" + page + "'>" +
   "<entity name='account'> " +
      "<attribute name = 'createdon'/> " +
      "<attribute name = 'name' /> " +
      "<attribute name = 'accountnumber' /> " +
      "<attribute name = 'telephone1' /> " +
    "</entity> " +
    "</fetch>";

            string url = !String.IsNullOrEmpty(accountName) ?
    "accounts?fetchXml=" + fetchXml + "&$filter=contains(name,'" + accountName + "')&$orderby= " + sortOrder + " " + sortType :
    "accounts?fetchXml=" + fetchXml + "&$orderby=" + sortOrder + " " + sortType;

            var accounts = await _account.Request<AccountsModel>(HttpMethod.Get, url);
            return Ok(accounts);
        }

        [HttpPost]
        public async void Post(AccountsModel accountsModel)
        {
            await _account.Request(HttpMethod.Post, "accounts", accountsModel);
        }
    }
}
