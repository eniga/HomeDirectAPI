using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDirectAPI.Models;
using HomeDirectAPI.Repositories;
using Microsoft.AspNetCore.Http;
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
        public ListLoanResponse List([FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
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
        public long GetPendingCount()
        {
            return repo.List(null, null).loans.Count;
        }

        [HttpGet("pending/bank/{bankId}")]
        public ListLoanResponse GetPending(long bankId, [FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.List(StartDate, EndDate);
        }

        [HttpGet("transmitted")]
        public ListLoanResponse GetTransmitted([FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.List(StartDate, EndDate);
        }

        [HttpGet("transmitted/bank/{bankId}")]
        public ListLoanResponse GetTransmitted(long bankId, [FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.List(StartDate, EndDate);
        }

        [HttpGet("transmitted/count")]
        public long GetTransmittedCount()
        {
            return repo.List(null, null).loans.Count;
        }

        // GET api/values/5
        [HttpGet("{loanID}")]
        public LoanResponse Get(long loanID)
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
        public Response Delete(long LoanID)
        {
            return repo.Delete(LoanID);
        }

        [HttpGet("bank/{bankId}")]
        public ListLoanResponse GetByBank(long bankId, [FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.GetByBank(bankId, StartDate, EndDate);
        }

        [HttpPost("report/{LoanID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerAcquisitionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomerAcquisitionFailedResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        public ActionResult GetLoanReport(long LoanID)
        {
            var result = repo.GetCustomerAcquisitionByLoanID(LoanID);
            if (result.GetType() == typeof(Response))
                return NotFound(result);
            return NoContent();
        }

        [HttpGet("bank/group")]
        public LoanGroupByBankResponse GetLoanGroupByBank()
        {
            return repo.GetLoanGroupByBank();
        }

        [HttpGet("AdvanceQuery")]
        public AdvanceQueryResponse AdvanceQuery(string Country = null)
        {
            return repo.AdvanceQuery(Country);
        }
    }
}
