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
    public class LoanPartnerController : Controller
    {
        LoanPartnersRepository repo;

        public LoanPartnerController(IConfiguration configuration)
        {
            repo = new LoanPartnersRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListpartersResponse List()
        {
            return repo.List();
        }

        [HttpGet("UserID")]
        public ListpartersResponse GetPartnersByUserID(int userID)
        {

            return repo.GetPartnerByUserID(userID);
        }

        // GET api/values/5


        // POST api/values
        [HttpPost]
        public Response Post([FromBody]LoanPartners value)
        {
            return repo.Add(value);
        }


        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]MortgageLoanApplication value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{MortgageLoanID}")]
        public Response Delete(int MortgageLoanID)
        {
            return repo.Delete(MortgageLoanID);
        }
    }
}
