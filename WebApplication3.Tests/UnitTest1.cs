using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3.Controllers;
using WebApplication3.Models;

namespace WebApplication3.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetProduct()
        {
            //Setup
            var controller = new ProductController();
            List<Product> products = (new List<Product>(controller.products));
 
            //Action
            var result = controller.GetProduct(2) as OkNegotiatedContentResult<Product>;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Name, products[1].Name );



        }

        [TestMethod]
        public void GetProduct_ShouldReturnWrongProduct()
        {
            var controller = new ProductController();
            List<Product> products = new List<Product>(controller.products);

            var result = controller.GetProduct(1) as OkNegotiatedContentResult<Product>;
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Content.Name, products[1]);

        }

        [TestMethod]
        public async Task GetProductAsync_ShouldReturnCorrectProduct()
        {
            var pIndex = 1;
            var controller = new ProductController();
            List<Product> products = new List<Product>(controller.products);

            var result = await controller.GetProductAsync(pIndex) as OkNegotiatedContentResult<Product>;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Name, products[pIndex-1].Name);



        }


        [TestMethod]
        public void SaveProduct_ShouldReturnSimpleOK()
        {
            var p = new Product();
            p.Name = "test";
            p.Id = 4;
            p.Category = "testcat";

            var controller = new ProductController();
            Task<IHttpActionResult> response = controller.SaveProduct(p);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response.Result, typeof(OkResult));

        }

        [TestMethod]
        public void TestGetAllAgain_ShouldReturnAllProducts()
        {
            var controller = new ProductController();
            Task<IHttpActionResult> response = controller.Func1GetAllOkAsync();
            List<Product> testList = new List<Product>();

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response.Result, typeof(OkNegotiatedContentResult<IEnumerable<Product>>));


        }


        //[TestMethod]
        //public void GetProductList_ShouldReturnAllProducts()
        //{
        //    var controller = new ProductController();
        //    IEnumerable<Product> products = new List<Product>(controller.products);

        //    var response = controller.GetProductList();
        //    Assert.IsNotNull(response);
        //    Assert.AreEqual(response, products);

        //}

    }
}
