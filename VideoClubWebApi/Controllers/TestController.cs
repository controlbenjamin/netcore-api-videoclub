using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VideoClubWebApi.Models;

namespace VideoClubWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private string _connectionStrings = string.Empty;

        private readonly IConfiguration _configuration;
        private readonly ILogger<Cliente> _logger;

        public TestController(IConfiguration configuration, ILogger<Cliente> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }


        [HttpGet]
        public string Get()
        {

            _connectionStrings += "\ndbAZURE: => " + _configuration["ConnectionStrings:DefaultConnectionAzure"];
            _connectionStrings += "\ndbLOCAL: => " + _configuration["ConnectionStrings:DefaultConnectionLocal"];
            _connectionStrings += "\nPROVEEDOR: => " + _configuration["ConnectionStrings:ProviderName"];
            return _connectionStrings;
        }
    }
}
