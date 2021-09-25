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
    public class RepaymentHistoryController : Controller
    {
        RepaymentHistoryRepository repo;

        public RepaymentHistoryController(IConfiguration configuration)
        {
            repo = new RepaymentHistoryRepository(configuration);
        }

        [HttpGet("{LoanId}")]
        public ListRepaymentHistoryResponse List(long LoanId)
        {
            return repo.List(LoanId);
        }

        [HttpGet("{RepaymentID}")]
        public RepaymentHistoryResponse Get(long RepaymentID)
        {
            return repo.Read(RepaymentID);
        }

        [HttpGet("Total")]
        public TotalRepaymentsResponse TotalRepayment()
        {
            return repo.TotalRepayment();
        }

        [HttpGet("Recent")]
        public ListRepaymentHistoryResponse RecentRepayments()
        {
            return repo.RecentRepayments();
        }

        [HttpPost]
        public Response Post([FromBody] RepaymentHistory request)
        {
            return repo.Add(request);
        }

        [HttpPut]
        public Response Put([FromBody] RepaymentHistory request)
        {
            return repo.Update(request);
        }

        [HttpDelete("{RepaymentID}")]
        public Response Delete(long RepaymentID)
        {
            return repo.Delete(RepaymentID);
        }
    }
}
