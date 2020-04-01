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
    public class DeveloperController : Controller
    {
        DeveloperRepository repo;

        public DeveloperController(IConfiguration configuration)
        {
            repo = new DeveloperRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListDeveloperResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{DeveloperId}")]
        public DeveloperResponse Read(int DeveloperId)
        {
            return repo.Read(DeveloperId);
        }

        [HttpGet("Email/{Email}")]
        public DeveloperResponse ReadByEmail(string Email)
        {
            return repo.ReadByEmail(Email);
        }

        [HttpGet("Phone/{PhoneNumber}")]
        public DeveloperResponse ReadByPhone(string PhoneNumber)
        {
            return repo.ReadByPhone(PhoneNumber);
        }

        // POST api/values
        [HttpPost]
        public Response Add([FromBody]Developers value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Update([FromBody]Developers value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{DeveloperId}")]
        public Response Delete(int DeveloperId)
        {
            return repo.Delete(DeveloperId);
        }

        [HttpPost("Login")]
        public DeveloperResponse Authenticate([FromBody] Login login)
        {
            return repo.Authenticate(login);
        }
    }
}
