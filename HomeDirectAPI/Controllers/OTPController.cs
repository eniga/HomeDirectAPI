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
    public class OTPController : Controller
    {
        OTPRepository repo;

        public OTPController(IConfiguration configuration)
        {
            repo = new OTPRepository(configuration);
        }

        // POST api/values
        [HttpPost("Generate")]
        public Response Generate([FromBody]GenerateOTPRequest value)
        {
            return repo.Generate(value);
        }

        // POST api/values
        [HttpPost("Validate")]
        public Response Validate([FromBody]ValidateOTPRequest value)
        {
            return repo.Validate(value);
        }
    }
}
