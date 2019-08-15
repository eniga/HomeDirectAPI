using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HomeDirectAPI.Controllers
{
    public class StatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult GetState()
        //{
        //    JsonSerializer serializer = new JsonSerializer();
        //    var obj = serializer.Deserialize<MyObject>(File.ReadAllText(@".\path\to\json\config\file.json");
        //    return View();
        //}
    }
}