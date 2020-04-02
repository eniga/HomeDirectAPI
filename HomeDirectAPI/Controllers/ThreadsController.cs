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
    public class ThreadsController : Controller
    {
        ThreadRepository repo;

        public ThreadsController(IConfiguration configuration)
        {
            repo = new ThreadRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListThreadResponse List()
        {
            return repo.List();
        }

        // GET: api/values
        [HttpGet("Thread/{ThreadId}")]
        public ListThreadResponse ListByThreadId(string ThreadId)
        {
            return repo.ListByThreadId(ThreadId);
        }

        // GET: api/values
        [HttpGet("Sender/{SenderId}")]
        public ListThreadResponse ListBySenderId(string SenderId)
        {
            return repo.ListBySenderId(SenderId);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ThreadResponse Get(int id)
        {
            return repo.Read(id);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Thread value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Response Put([FromBody]Thread value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
