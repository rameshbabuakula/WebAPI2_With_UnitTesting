using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebApplication3.Models;
using System.Web.Http.Cors;

namespace WebApplication3.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        public Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 

        };

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        //[HttpGet]
        //public IEnumerable<Product> GetProductList()
        //{
        //    return products.ToList();
        //}
            
            
        [HttpGet]
        public Product _GetSpecific()
        {
            return products[1];
        }

        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            //Task<string> returnedTaskResult =  TestStringAsync(name: "BillJ", size: 23);
            //var result = returnedTaskResult.Result;
            //string strResult = await returnedTaskResult;
            //return returnedTaskResult.Result;

           

            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
                return NotFound();
            else
                return Ok(product );

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProductAsync(int id)
        {
            //Task<string> returnedTaskResult = TestStringAsync(name: "BillJ", size: 23);
            //var result = returnedTaskResult.Result;
            //string strResult = await returnedTaskResult;
            //return returnedTaskResult.Result;

            //var x = await Task.FromResult(GetProduct(id));


            //var product = products.FirstOrDefault((p) => p.Id == id);
            //if (product == null)
            //    return NotFound();
            //else
            //    return  Ok(x);

            return await Task.FromResult(GetProduct(id));

        }

        [HttpGet]
        public async Task<IHttpActionResult> Func1GetAllOkAsync()
        {
            var x = await Task.FromResult(GetAllProducts());

            return Ok(x);
        }





        [HttpPost]
        public async Task<IHttpActionResult> SaveProduct(Product p)
        {
            return Ok();
            //return InternalServerError();
        }


        async Task<string> TestStringAsync(int size, string name)
        {
            int subResult = await TestSubAsynTask(3);



            var s = string.Format("Size = {0} =>{2}, Name = {1}", size, name, subResult);

            return s;

        }

        async Task<int> TestSubAsynTask(int input)
        {

            return input + 1;
        }

        async Task<string> TestSub3Task(string input)
        {
            return input + " hi";
        }

        async Task TestAboveTask()
        {
            var x = await Task.FromResult(TestSub3Task("Bill"));
            string s = x.Result;
        }

      


    }
}
