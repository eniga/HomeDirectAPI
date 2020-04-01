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
    public class BranchConfigController : Controller
    {
        BankConfigRepository repo;

        public BranchConfigController(IConfiguration configuration)
        {
            repo = new BankConfigRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListBankConfigResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{ConfigID}")]
        public BankConfigResponse Get(int ConfigID)
        {
            return repo.Read(ConfigID);
        }

        // POST api/values
        [HttpPost]
        public Response Add([FromBody]BankConfig value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Update([FromBody]BankConfig value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{ConfigID}")]
        public Response Delete(int ConfigID)
        {
            return repo.Delete(ConfigID);
        }
    }
}
