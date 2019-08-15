using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDirectAPI.Models;
using HomeDirectAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HomeDirectAPI.Controllers
{
    [Route("api/[controller]")]
    public class MortgageController : Controller
    {
        MortgageRepository repo;

        public MortgageController(IConfiguration configuration)
        {
            repo = new MortgageRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListMortgageLoanResponse Get()
        {
            return repo.List();
        }
        [HttpGet("Email")]
        public ListMortgageLoanResponse Get(string email)
        {

            return repo.GetLoanByEmail(email);
        }

        [HttpGet("UserID")]
        public ListMortgageLoanResponse GetLoanByUserID(int userID)
        {

            return repo.GetLoanByUserID(userID);
        }

        [HttpGet("Loan/Count")]
        public int GetCount(string email)
        {

            return repo.GetLoanByEmail(email).applications.Count;
        }
        // GET api/values/5
        [HttpGet("{MortgageLoanID}")]
        public MortgageLoanResponse Get(int MortgageLoanID)
        {
            return repo.Read(MortgageLoanID);
        }

        // POST api/values
        [HttpPost]
        public MortgageResponse Post([FromBody]MortgageLoanApplication value)
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