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
    public class UserController : Controller
    {
        UserRepository repo;

        public UserController(IConfiguration configuration)
        {
            repo = new UserRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListUserResponse GetAllUsers()
        {
            return repo.List();
        }

        [HttpGet("ByUserType/{UserType}")]
        public ListUserResponse ListByUserTypes(string UserType)
        {
            return repo.ListByUserTypes(UserType);
        }

        // GET api/values/5
        [HttpGet("{UserID}")]
        public UserResponse GetUser(int UserID)
        {
            return repo.Read(UserID);
        }

        [HttpGet("Email")]
        public Response GetUserbyemail(string email)
        {

            return repo.GetUserByEmail(email);
        }

        // POST api/values
        [HttpPost]
        public Response AddUser([FromBody]User value)
        {
            return repo.Add(value);
        }

        // POST api/values
        [HttpPost("Authenticate")]
        public Response AuthenticateUser([FromBody]Login value)
        {

            return repo.Authenticate(value.Email, value.password);
        }

        // PUT api/values/5
        [HttpPut]
        public Response UpdateUser([FromBody]User value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{UserID}")]
        public Response DeleteUser(int UserID)
        {
            return repo.Delete(UserID);
        }
    }
}
