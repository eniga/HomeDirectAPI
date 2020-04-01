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
    public class PropertyDocumentsController : Controller
    {
        PropertyDocumentsRepository repo;

        public PropertyDocumentsController(IConfiguration configuration)
        {
            repo = new PropertyDocumentsRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListPropertyDocumentsResponse List()
        {
            return repo.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PropertyDocumentsResponse Get(int id)
        {
            return repo.Read(id);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]PropertyDocuments value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]PropertyDocuments value)
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
