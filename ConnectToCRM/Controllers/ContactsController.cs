﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConnectToCRM.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
        public async Task<string> Get()
        {
            CrmConnection crmConnection = new CrmConnection(_config);
            return await crmConnection.CrmRequestWithParametr("contacts");
        }
    }
}
