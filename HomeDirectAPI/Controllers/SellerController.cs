using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDirectAPI.Models;
using HomeDirectAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeDirectAPI.Controllers
{
    [Route("api/[controller]")]
    public class SellerController : Controller
    {
        SellerRepository repo;

        public SellerController(IConfiguration configuration)
        {
            repo = new SellerRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListSellerResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{SellerID}")]
        public SellerResponse Get(int SellerID)
        {
            return repo.Read(SellerID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Seller value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Seller value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{SellerID}")]
        public Response Delete(int SellerID)
        {
            return repo.Delete(SellerID);
        }
    }
}
