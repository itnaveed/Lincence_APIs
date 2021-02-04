using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logics;
using Database;
using Common;
using ViewModels;

namespace Lincence_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AuthorizeController : ControllerBase
    {
        [HttpPost]

        [Authorize]
        [Route("allowservice")]
        public async Task<IActionResult> AllowService(Authorize auth)
        {
            
            AllowServiceBLL authbll = new AllowServiceBLL();

            authbll.Authorize(auth);
            return Ok("dd");
        }

        [HttpDelete]
        [Route("removeAuthorize/{ID}")]
        public IActionResult removeAuthorize(int ID = 0)
        {
            AllowServiceBLL serbll = new AllowServiceBLL();
            var data = serbll.removeAuth(ID);
            if(data!= null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("");
            }
            
        }


    }
}
