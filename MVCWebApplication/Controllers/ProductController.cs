using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication.Controllers
{
    [Route("Store")]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [Route("Buy")]
        [Route("Checkout")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
