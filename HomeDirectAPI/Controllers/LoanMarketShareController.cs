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
    public class LoanMarketShareController : Controller
    {
        LoanMarketShareRepository repo;

        public LoanMarketShareController(IConfiguration configuration)
        {
            repo = new LoanMarketShareRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListLoanMarketShareResponse List([FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.List(StartDate, EndDate);
        }

        // GET api/values/5
        [HttpGet("{ShareID}")]
        public LoanMarketShareResponse Get(int ShareID)
        {
            return repo.Read(ShareID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]LoanMarketShare value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]LoanMarketShare value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{ShareID}")]
        public Response Delete(int ShareID)
        {
            return repo.Delete(ShareID);
        }
    }
}
