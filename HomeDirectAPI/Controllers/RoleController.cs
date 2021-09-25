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
    public class RoleController : Controller
    {
        RoleRepository repo;

        public RoleController(IConfiguration configuration)
        {
            repo = new RoleRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListRoleResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{RoleID}")]
        public RoleResponse Get(long RoleID)
        {
            return repo.Read(RoleID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Role value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Role value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{RoleID}")]
        public Response Delete(long RoleID)
        {
            return repo.Delete(RoleID);
        }
    }
}
