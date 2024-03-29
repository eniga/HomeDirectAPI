﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDirectAPI.Models;
using HomeDirectAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HomeDirectAPI.Controllers
{
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        StateRepository repo;

        public StatesController(IConfiguration configuration)
        {
            repo = new StateRepository(configuration);
        }

        [HttpGet]
        public ListStateResponse GetState()
        {
            return repo.List();
        }

        [HttpGet("Lga")]
        public LGAResponse GetByLga(long stateID)
        {
            return repo.LgaByStateID(stateID);
        }

        [HttpGet("LgaID")]
        public LGAsResponse GetLGAByID(long LgaID)
        {
            return repo.GetLgaID(LgaID);
        }

        [HttpGet("StateID")]
        public StateResponse GetStateByStateID(long stateID)
        {
            return repo.GetstatebyID(stateID);
        }
    }
}