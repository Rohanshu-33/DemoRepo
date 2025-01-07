using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Results;
using UserLibraryApi.Helpers;
using UserLibraryApi.Models;

namespace UserLibraryApi.Controllers
{
    public class UserV2Controller : ApiController
    {
        internal static List<UserV2> Users = new List<UserV2>();

        // user signup
        [HttpPost]
        [Route("user/v2/signup")]
        public IHttpActionResult Signup([FromBody] UserV2 usr)
        {
            try
            {
                if (usr == null) return NotFound();
                if (string.IsNullOrWhiteSpace(usr.Username) || string.IsNullOrWhiteSpace(usr.Email) || usr.Password.Count() < 4) return BadRequest("Check credentials.");
                if (Users.Any(u => u.Username == usr.Username)) return BadRequest("User already Exists.");
                Users.Add(usr);
                return Ok(new {Message = "Signup successful.", Signal="green"});
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // user login
        [HttpPost]
        [RouteAttribute("user/v2/login")]
        public IHttpActionResult Login([FromBody] UserV2 usr)
        {
            try
            {
                if (usr == null) return NotFound();
                if (string.IsNullOrWhiteSpace(usr.Username) || string.IsNullOrWhiteSpace(usr.Email) || usr.Password.Count() < 4) return BadRequest("Check credentials.");
                if (Users.Any(e=>e.Username==usr.Username))
                {
                    string jwtToken = JWTHelper.GenerateToken(usr.Username);
                    return Ok(new { message = "Login successful.", token = jwtToken });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GreetUser()
        {
            return Ok("localhost started.");
        }
    }
}
