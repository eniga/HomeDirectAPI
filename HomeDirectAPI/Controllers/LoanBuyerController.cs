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
    public class LoanBuyerController : Controller
    {
        LoanBuyerRepository repo;

        public LoanBuyerController(IConfiguration configuration)
        {
            repo = new LoanBuyerRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListLoanBuyerResponse Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{LoanBuyerID}")]
        public LoanBuyerResponse Get(int LoanBuyerID)
        {
            return repo.Read(LoanBuyerID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]LoanBuyer value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]LoanBuyer value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{LoanBuyerID}")]
        public Response Delete(int LoanBuyerID)
        {
            return repo.Delete(LoanBuyerID);
        }
    }
}
