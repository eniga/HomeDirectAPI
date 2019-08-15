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
    public class BankBranchController : Controller
    {
        BankBranchRepository repo;

        public BankBranchController(IConfiguration configuration)
        {
            repo = new BankBranchRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListBankBranchesResponse Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{BranchID}")]
        public BankBranchesResponse Get(int BranchID)
        {
            return repo.Read(BranchID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]BankBranch value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]BankBranch value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{BranchID}")]
        public Response Delete(int BranchID)
        {
            return repo.Delete(BranchID);
        }
    }
}
