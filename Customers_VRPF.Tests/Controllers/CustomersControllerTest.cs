using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Customers_VRPF;
using Customers_VRPF.Controllers;
using Customers_VRPF.DataTransferObjects;
using Customers_VRPF.Models;

namespace Customers_VRPF.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            var controller = new CustomersController();

            // Act
            var actionResult = controller.Get();
            var response = actionResult as OkNegotiatedContentResult<IQueryable<CustomerDto>>;
            var response2 = response.Content.ToArray();
            // Assert
            Assert.IsNotNull(response2);
            Assert.AreEqual(5, response2.Count());
            Assert.AreEqual("Mette", response2.ElementAt(0).Name);
            Assert.AreEqual("Vasco", response2.ElementAt(1).Name);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            var controller = new CustomersController();

            // Act
            var actionResult = controller.Get(1);
            var response = actionResult as OkNegotiatedContentResult<CustomerDto>;
            // Assert
            Assert.AreEqual("Mette", response.Content.Name);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            CustomersController controller = new CustomersController();

            // Act
            controller.Post(new Customer {Name = "Test1", Address = "Reidulvs gate 5", City = "Trondheim", Country = "Norge" });

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            CustomersController controller = new CustomersController();

            // Act
            controller.Put(5, new Customer { Id = 5, Name = "Test2", Address = "Reidulvs gate 5", City = "Trondheim", Country = "Norge" });

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            CustomersController controller = new CustomersController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
