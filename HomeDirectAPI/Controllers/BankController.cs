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
    public class BankController : Controller
    {
        BankRepository repo;

        public BankController(IConfiguration configuration)
        {
               repo = new BankRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListBankResponse Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{BankID}")]
        public BankResponse Get(int BankID)
        {
            return repo.Read(BankID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Bank value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Bank value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{BankID}")]
        public Response Delete(int BankID)
        {
            return repo.Delete(BankID);
        }
    }
}
