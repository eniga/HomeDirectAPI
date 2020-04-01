﻿using System;
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
    public class MessagesController : Controller
    {
        MessagesRepository repo;

        public MessagesController(IConfiguration configuration)
        {
            repo = new MessagesRepository(configuration);
        }

        // GET: api/values
        [HttpGet]
        public ListMessagesResponse List()
        {
            return repo.List();
        }

        [HttpGet("inbox/{userId}")]
        public ListMessagesResponse MyInbox(int userId)
        {
            return repo.MyInbox(userId);
        }

        [HttpGet("outbox/{userId}")]
        public ListMessagesResponse MyOutbox(int userId)
        {
            return repo.MyOutbox(userId);
        }

        // GET api/values/5
        [HttpGet("{MessageID}")]
        public MessagesResponse Get(int MessageID)
        {
            return repo.Read(MessageID);
        }

        // POST api/values
        [HttpPost]
        public Response Post([FromBody]Messages value)
        {
            return repo.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public Response Put([FromBody]Messages value)
        {
            return repo.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{MessageID}")]
        public Response Delete(int MessageID)
        {
            return repo.Delete(MessageID);
        }
    }
}
