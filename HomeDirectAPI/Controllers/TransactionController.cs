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
    public class TransactionController : Controller
    {
        TransactionRepository repo;

        public TransactionController(IConfiguration configuration)
        {
            repo = new TransactionRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListTransactionResponse List([FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.List(StartDate, EndDate);
        }

        // GET api/values/5
        [HttpGet("{TxnID}")]
        public TransactionResponse Get(long TxnID)
        {
            return repo.Read(TxnID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Transaction value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Transaction value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{TxnID}")]
        public Response Delete(long TxnID)
        {
            return repo.Delete(TxnID);
        }
    }
}
