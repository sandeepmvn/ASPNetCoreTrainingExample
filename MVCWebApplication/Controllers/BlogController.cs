using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication.Controllers
{
    //[Route("[controller]")]
    public class BlogController : Controller
    {
        //[Route("blog")]
        //[Route("")]
        //[HttpGet("")]
        public IActionResult Articles()
        {
            return View();
        }

        //[Route("{articleName}")]
        //s[HttpGet("{articleName}")]
        public IActionResult Article(string articleName)
        {

            return RedirectToRoute("blogRoute");
           // return Content(articleName);
        }
    }
}
