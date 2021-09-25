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
    public class LoanPortfolioController : Controller
    {
        LoanPortfolioRepository repo;

        public LoanPortfolioController(IConfiguration configuration)
        {
            repo = new LoanPortfolioRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListLoanPortfolioResponse List([FromQuery] DateTime? StartDate = null, [FromQuery] DateTime? EndDate = null)
        {
            return repo.List(StartDate, EndDate);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public LoanPortfolioResponse Get(long id)
        {
            return repo.Get(id);
        }

        [HttpGet("tranches/{BankId}")]
        public ListBankTranchesResponse ListBankTranches(long BankId)
        {
            return repo.ListBankTranches(BankId);
        }
    }
}
