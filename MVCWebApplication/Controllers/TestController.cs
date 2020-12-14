using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MVCWebApplication.Utility;

namespace MVCWebApplication.Controllers
{
    public class TestController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly IOptions<Helper> _options;
        public TestController(IConfiguration configuration, IWebHostEnvironment environment,IOptions<Helper> options, IOptionsSnapshot<Helper> optionsSnapshot)
        {
            _configuration = configuration;
            _environment = environment;
            _options = options;
        }
        public IActionResult Index()
        {
            //var envName = _environment.EnvironmentName;
            //var settings1 = _configuration["Settings1"];
            ////var setting2 = _configuration.Ge
            //var connectionstring = _configuration.GetConnectionString("Default2");
            //var connectionstring1 = _configuration["ConnectionStrings:Default"];

            var connectionString = _options.Value.ConnectionStrings.Default;
            return View();
        }
    }
}
