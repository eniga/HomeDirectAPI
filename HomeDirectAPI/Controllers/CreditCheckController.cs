using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDirectAPI.Models;
using HomeDirectAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeDirectAPI.Controllers
{
    [Route("api/[controller]")]
    public class CreditCheckController : Controller
    {
        CustomerAcquisitionService service;

        public CreditCheckController(IConfiguration configuration)
        {
            service = new CustomerAcquisitionService(configuration);
        }

        [HttpGet("RequestToken")]
        public OauthTokenDetails RequestToken()
        {
            return service.RequestToken();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerAcquisitionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomerAcquisitionFailedResponse))]
        public ActionResult GetCustomerAcquisition([FromBody]CustomerAcquisitionRequest request)
        {
            var response = service.GetCustomerAcquisition(request);
            if (response != null)
            {
                if (response.GetType() == typeof(CustomerAcquisitionResponse))
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
