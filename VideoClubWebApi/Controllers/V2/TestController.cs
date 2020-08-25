using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VideoClubWebApi.Models;

namespace VideoClubWebApi.Controllers.V2
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private string _connectionStrings = string.Empty;

        private readonly IConfiguration _configuration;
        private readonly ILogger<Cliente> _logger;
        private readonly VideoClubDbContext _context;

        public TestController(IConfiguration configuration, ILogger<Cliente> logger, VideoClubDbContext context)
        {
            _configuration = configuration;
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Cliente> Get()
        {

            _connectionStrings += "\ndbAZURE: => " + _configuration["ConnectionStrings:DefaultConnectionAzure"];
            _connectionStrings += "\ndbLOCAL: => " + _configuration["ConnectionStrings:DefaultConnectionLocal"];
            _connectionStrings += "\nPROVEEDOR: => " + _configuration["ConnectionStrings:ProviderName"];

            /*OUTPUT:
             
dbAZURE: => Server=tcp:sql-server-azure-benja.database.windows.net,1433;Initial Catalog=dbVideoClubAzure;Persist Security Info=False;User ID=benjadmin;Password=Benja4026;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
dbLOCAL: => Server=NOTEBENJA\SQLEXPRESS;Database=dbVideoClubLocal;Trusted_Connection=True;
PROVEEDOR: => System.Data.SqlClient
             
             
             */

            return _context.Clientes.ToList();
        }
    }
}
