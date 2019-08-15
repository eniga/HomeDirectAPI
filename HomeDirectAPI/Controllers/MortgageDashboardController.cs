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
    public class MortgageDashboardController : Controller
    {
        MortgageDashboardRepository repo;

        public MortgageDashboardController(IConfiguration configuration)
        {
            repo = new MortgageDashboardRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListMortgageDashboard Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{Year}")]
        public MortgageDashboardDetails Get(int Year)
        {
            return repo.Get(Year);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
