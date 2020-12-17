using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPIExample.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPIExample.Controllers.Tests
{
    public class DepartmentsAPIControllerTests
    {
        [TestMethod()]
        public void  GetDepartmentTest()
        {
            // Arrange
            DepartmentsAPIController departmentsAPIController = new DepartmentsAPIController(new Models.SampleCoreDBContext());
            // Act
            var res= departmentsAPIController.GetDepartment().Result;
            //Assert
            Assert.IsInstanceOfType(res,typeof(ActionResult<IEnumerable<Models.Department>>));
        }
    }
}