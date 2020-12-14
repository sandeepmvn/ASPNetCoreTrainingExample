using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MVCWebApplication.Controllers
{
    public class CachingExController : Controller
    {
        private readonly IMemoryCache _cache;
        public CachingExController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public IActionResult Index(int id)
        {
            List<string> values = null;
            if (!_cache.TryGetValue<List<string>>("lstvalues",out values))
            {
                values = new List<string>() { "v1", "v2", "v3" };
                _cache.Set<List<string>>("lstvalues", values,);
            }
           // _cache.Remove("lstvalues");
            return View(values);
        }
    }
}
