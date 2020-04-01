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
    public class UserCategoryController : Controller
    {
        UserCategoryRepository repo;

        public UserCategoryController(IConfiguration configuration)
        {
            repo = new UserCategoryRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListUserCategoryResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{CatID}")]
        public UserCategoryResponse Get(int CatID)
        {
            return repo.Read(CatID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]UserCategory value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]UserCategory value)
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
