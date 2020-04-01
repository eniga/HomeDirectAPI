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
    public class WalletsController : Controller
    {
        WalletRepository repo;

        public WalletsController(IConfiguration configuration)
        {
            repo = new WalletRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListWalletResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public WalletResponse Get(int id)
        {
            return repo.Read(id);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Wallet value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Wallet value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
