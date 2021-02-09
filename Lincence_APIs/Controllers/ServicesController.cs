using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Business_Logics;
using Microsoft.AspNetCore.Authorization;
using ViewModels;

namespace Lincence_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        
        [Route("AddService")]
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddService(Service _service)
        {
            try
            {
                ServiceBLL ser = new ServiceBLL();
                ser.AddService(_service);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [Route("updateService")]
        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> UpdateService(Service _service)
        {
            try
            {
                ServiceBLL ser = new ServiceBLL();
                ser.AddService(_service);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        //[Authorize]
        [HttpGet]
        [Route("ServicesList")]
        public IEnumerable<Service> ServicesList()
        {
            ServiceBLL serbll = new ServiceBLL();
            return serbll.ServicesList();
        }

        [HttpGet]
        [Route("userServices/{ID}")]
        public IEnumerable<UserServicesVM> userServices(int ID=0)
        {
            ServiceBLL serbll = new ServiceBLL();
            return serbll.userServices(ID);
        }
        [HttpGet]
        [Route("notAssignService/{ID}")]
        public IEnumerable<Service> notAssignService(int ID = 0)
        {
            ServiceBLL serbll = new ServiceBLL();
            return serbll.notAssignServices(ID);
        }

    }
}
