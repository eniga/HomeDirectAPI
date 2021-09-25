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
    public class CustomerController : Controller
    {
        CustomerRepository repo;

        public CustomerController(IConfiguration configuration)
        {
            repo = new CustomerRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListCustomerResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{CustomerId}")]
        public CustomerResponse Read(long CustomerId)
        {
            return repo.Read(CustomerId);
        }

        [HttpGet("Email/{Email}")]
        public CustomerResponse ReadByEmail(string Email)
        {
            return repo.ReadByEmail(Email);
        }

        [HttpGet("Phone/{PhoneNumber}")]
        public CustomerResponse ReadByPhone(string PhoneNumber)
        {
            return repo.ReadByPhone(PhoneNumber);
        }

        // POST api/values
        [HttpPost]
        public Response Add([FromBody]Customers value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Update([FromBody]Customers value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{CustomerId}")]
        public Response Delete(long CustomerId)
        {
            return repo.Delete(CustomerId);
        }

        [HttpPost("Login")]
        public CustomerResponse Authenticate([FromBody] Login login)
        {
            return repo.Authenticate(login);
        }
    }
}
