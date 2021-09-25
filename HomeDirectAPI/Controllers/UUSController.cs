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
    public class UUSController : Controller
    {
        UUSBanksRepository repo;

        public UUSController(IConfiguration configuration)
        {
            repo = new UUSBanksRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListUUSBanksResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{BankId}")]
        public UUSBanksResponse Get(long BankId)
        {
            return repo.Read(BankId);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]UUSBanks value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]UUSBanks value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{BankId}")]
        public Response Delete(long BankId)
        {
            return repo.Delete(BankId);
        }
    }
}
