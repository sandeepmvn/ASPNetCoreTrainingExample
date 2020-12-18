using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApplicationExample.Models;

namespace RazorWebApplicationExample.Pages
{
    public class CreateDepartmentPageModel : PageModel
    {

        private readonly IWebHostEnvironment _env;
        public CreateDepartmentPageModel(IWebHostEnvironment environment)
        {
            _env = environment;
        }

        [BindProperty]
        public DepartmentAPIModels DepartmentAPIModel { get; set; }
        [BindProperty]
        public List<IFormFile> UploadDeptFiles { get; set; }
        public void OnGet()
        {
            DepartmentAPIModel = new DepartmentAPIModels()
            {
                PkdepartmentId = 1,
                DepartmentName = "IT",
                IsActive = true
            };
        }


        public async Task OnPost(IFormFile deptfile)
        {
            if (ModelState.IsValid)
            {
                var wwwrootpath = _env.WebRootPath;
                using (var fileStream = new FileStream(Path.Combine(wwwrootpath,deptfile.FileName), FileMode.Create, FileAccess.ReadWrite))
                {
                    await deptfile.CopyToAsync(fileStream);
                }


                foreach (var item in UploadDeptFiles)
                {
                    using (var stream = System.IO.File.Create(Path.Combine(wwwrootpath, item.FileName)))
                    {
                        await item.CopyToAsync(stream);
                    }
                }
            }
        }

    }
}
