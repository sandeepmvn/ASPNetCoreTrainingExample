using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVCWebApplication.Models;
using MVCWebApplication.Services;

namespace MVCWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMyDepedencyService _depedencyService;
        private readonly IHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment hostEnvironment,
            IMyDepedencyService depedencyService, IMyDepedencyService myDepedencyService)
        {
            _hostEnvironment = hostEnvironment;
            _logger = logger;
            //depedencyService = new MyDepedencyService();
            _depedencyService = depedencyService;
        }

       // [Authorize]
        [HttpGet]
        public IActionResult Index([FromServices] IMyDepedencyService my_DepedencyService)
        {
            //_depedencyService.WriteMessage("this is from index method");
            // return View();
            return Unauthorized();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetFile(string fileName, string contenttype)
        {
            var filepath = Path.Combine(_hostEnvironment.ContentRootPath, "mystaticfiles", fileName);
            return PhysicalFile(filepath, contenttype, fileName);
        }

        public IActionResult Page404()
        {
            return View();
        }


        public IActionResult Page401()
        {
            return View();
        }


    }
}
