using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Models;
using Newtonsoft.Json;

namespace MVCWebApplication.Controllers
{
    public class ConsumeDeptAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // HTTP Request to web API Server

            List<DepartmentAPIModel> departmentAPIModels = null; ;

            HttpClient httpClient = new HttpClient();

            var response=await httpClient.GetAsync("https://localhost:44349/api/DepartmentsAPI");
            if(response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                //Deserilaze the json object
                departmentAPIModels = JsonConvert.DeserializeObject<List<DepartmentAPIModel>>(res);
            }
            else
            {
                throw new ApplicationException("Http client error");
            }

            return View(departmentAPIModels);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(DepartmentAPIModel department)
        {
            HttpClient httpClient = new HttpClient();

            var serilizeddata=JsonConvert.SerializeObject(department);
            var httpcontent = new StringContent(serilizeddata,System.Text.Encoding.UTF8,"application/json");
           
            var response = await httpClient.PostAsync("https://localhost:44349/api/DepartmentsAPI", httpcontent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {

            }
            return View();
        }

    }
}
