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
    public class ListingsController : Controller
    {
        ListingsRepository repo;

        public ListingsController(IConfiguration configuration)
        {
            repo = new ListingsRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListListingsResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ListingsResponse GetListing(int id)
        {
            return repo.Read(id);
        }

        // POST api/values
        [HttpPost]
        public Response AddListing([FromBody]Listings value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response UpdateListing([FromBody]Listings value)
        {
            return repo.Update(value);
        }

        [HttpPut("UpdateStatus/{id}")]
        public Response UpdateListingStatus(int id, [FromBody]Listings value)
        {
            return repo.UpdateStatus(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Response DeleteListing(int id)
        {
            return repo.Delete(id);
        }
    }
}
