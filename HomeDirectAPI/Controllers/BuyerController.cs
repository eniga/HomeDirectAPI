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
    public class BuyerController : Controller
    {
        BuyerRepository repo;

        public BuyerController(IConfiguration configuration)
        {
            repo = new BuyerRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListBuyerResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{BuyerID}")]
        public BuyerResponse Read(long BuyerID)
        {
            return repo.Read(BuyerID);
        }

        // POST api/values
        [HttpPost]
        public Response Add([FromBody]Buyer value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Update([FromBody]Buyer value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{BuyerID}")]
        public Response Delete(long BuyerID)
        {
            return repo.Delete(BuyerID);
        }
    }
}
