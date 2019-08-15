﻿using System;
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
    public class LoanController : Controller
    {
        LoanRepository repo;

        public LoanController(IConfiguration configuration)
        {
            repo = new LoanRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListLoanResponse Get([FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.List(StartDate, EndDate);
        }

        [HttpGet("recent")]
        public ListLoanResponse Recent([FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.RecentLoanRepayments(StartDate, EndDate);
        }

        [HttpGet("repaid")]
        public ListLoanResponse Repaid([FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.Repaid(StartDate, EndDate);
        }

        [HttpGet("pending")]
        public ListLoanResponse GetPending(DateTime? StartDate, DateTime? EndDate)
        {
            return repo.List(StartDate, EndDate);
        }

        [HttpGet("pending/count")]
        public int GetPendingCount()
        {
            return repo.List(null, null).loans.Count;
        }

        [HttpGet("pending/bank/{bankId}")]
        public ListLoanResponse GetPending(int bankId, [FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.List(StartDate, EndDate);
        }

        [HttpGet("transmitted")]
        public ListLoanResponse GetTransmitted([FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.List(StartDate, EndDate);
        }

        [HttpGet("transmitted/bank/{bankId}")]
        public ListLoanResponse GetTransmitted(int bankId, [FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.List(StartDate, EndDate);
        }

        [HttpGet("transmitted/count")]
        public int GetTransmittedCount()
        {
            return repo.List(null, null).loans.Count;
        }

        // GET api/values/5
        [HttpGet("{loanID}")]
        public LoanResponse Get(int loanID)
        {
            return repo.Read(loanID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Loans value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Loans value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{LoanID}")]
        public Response Delete(int LoanID)
        {
            return repo.Delete(LoanID);
        }

        [HttpGet("bank/{bankId}")]
        public ListLoanResponse GetByBank(int bankId, [FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.GetByBank(bankId, StartDate, EndDate);
        }

    }
}
