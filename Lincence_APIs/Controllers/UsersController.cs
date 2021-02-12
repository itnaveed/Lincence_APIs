using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logics;
using Database;
using Common;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Lincence_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        //[Authorize]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser(User admin)
        {
            admin.Password = Encryption.Encrypt(admin.Password, "asdfewrewqrss323");
            UsersBLL userbll = new UsersBLL();
           
           var userInfo = userbll.RegisterUser(admin);
            if(userInfo == null)
            {
                return BadRequest(new {message= "Email Already Exist.." });
            }
            else
            {
                return Ok(new {message = "User added successfully." });
            }
            
        }
        [HttpPost]
        [Route("LoginUser")]
        public IActionResult LoginUser(User users)
        {
            UsersBLL bll = new UsersBLL();
            users.Password = Encryption.Encrypt(users.Password, "asdfewrewqrss323");
            User user = bll.LoginUser(users.Email, users.Password);
            if (user != null)
            {
                if (user.IsActive == true)
                {
                    string Token = Common.JwtHelper.CreateToken(user);
                    ServiceBLL sbl = new ServiceBLL();
                   var allowedService =  sbl.UserServices(user.Id);
                    string baseURL = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                    // bll.UpdateUser(user);
                    return Ok(new { token = Token, service = allowedService, BaseURI = baseURL});
                }
                else
                {
                    return BadRequest("notactive");
                }
            }
            else
            {
                return BadRequest("nofound");
            }
        }

        //[Authorize]
        [HttpGet]
        [Route("UsersList")]
        public IEnumerable<User> UsersList()
        {
            //string accessToken = Request.Headers["Authorization"];
            //var data = JwtHelper.DecodeJWT(accessToken);
            UsersBLL userbll = new UsersBLL();
            return userbll.UsersList();
        }
        [HttpGet]
        [Route("GetDetail/{id}")]
        public User GetDetail(int id=0)
        {
            //string accessToken = Request.Headers["Authorization"];
            //var data = JwtHelper.DecodeJWT(accessToken);
            UsersBLL userbll = new UsersBLL();
            User userInfo = userbll.getDetail(id);
            userInfo.Password = Encryption.Decrypt(userInfo.Password, "asdfewrewqrss323");
            return userInfo;
        }
        [HttpPut]
        //[Authorize]
        [Route("updateUser")]
        public async Task<IActionResult> updateUser(User admin)
        {
            admin.Password = Encryption.Encrypt(admin.Password, "asdfewrewqrss323");
            UsersBLL userbll = new UsersBLL();

            var userInfo = userbll.RegisterUser(admin);
           
                return Ok(new { message = "User updated successfully." });
            

        }
    }
}
