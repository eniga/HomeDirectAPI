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
    public class LoanRatingController : Controller
    {
        LoanRatingRepository repo;

        public LoanRatingController(IConfiguration configuration)
        {
            repo = new LoanRatingRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListLoanRatingResponse Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{RatingID}")]
        public LoanRatingResponse Get(int RatingID)
        {
            return repo.Read(RatingID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]LoanRating value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]LoanRating value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{RatingID}")]
        public Response Delete(int RatingID)
        {
            return repo.Delete(RatingID);
        }
    }
}
