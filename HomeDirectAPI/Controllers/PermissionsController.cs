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
    public class PermissionsController : Controller
    {
        PermissionsRepository repo;

        public PermissionsController(IConfiguration configuration)
        {
            repo = new PermissionsRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListPermissionsResponse Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{PermID}")]
        public PermissionsResponse Get(int PermID)
        {
            return repo.Read(PermID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Permissions value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Permissions value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{PermID}")]
        public Response Delete(int PermID)
        {
            return repo.Delete(PermID);
        }
    }
}
