using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDirectAPI.Models;
using HomeDirectAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HomeDirectAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserTypesController : Controller
    {
        UserTypeRepository repo;

        public UserTypesController(IConfiguration configuration)
        {
            repo = new UserTypeRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListUserTypeResponse Get()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{CatID}")]
        public UserTypeResponse Get(int CatID)
        {
            return repo.Read(CatID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]UserTypes value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]UserTypes value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{CatID}")]
        public Response Delete(int CatID)
        {
            return repo.Delete(CatID);
        }
    }
}