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
    public class LoanDocController : Controller
    {
        LoanDocRepository repo;

        public LoanDocController(IConfiguration configuration)
        {
            repo = new LoanDocRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListLoanDocResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{DocID}")]
        public LoanDocResponse Get(long DocID)
        {
            return repo.Read(DocID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]LoanDoc value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]LoanDoc value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{DocID}")]
        public Response Delete(long DocID)
        {
            return repo.Delete(DocID);
        }
    }
}
