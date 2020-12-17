using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorWebApplicationExample.Models;

namespace RazorWebApplicationExample.Pages
{
    public class ConsumeDepartmentAPIModel : PageModel
    {
        public List<DepartmentAPIModels> DepartmentAPIModels { get; set; }

        public async Task OnGet()
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:44349/api/DepartmentsAPI");
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                //Deserilaze the json object
                DepartmentAPIModels = JsonConvert.DeserializeObject<List<DepartmentAPIModels>>(res);
            }
            else
            {
                throw new ApplicationException("Http client error");
            }

        }
    }
}
