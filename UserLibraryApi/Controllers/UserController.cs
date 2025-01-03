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
    public class UserController : ApiController
    {
        internal static readonly List<User> Users = new List<User>();

        // user signup
        [HttpPost]
        [Route("user/signup")]
        public IHttpActionResult Signup([FromBody] User usr)
        {
            try
            {
                if (usr == null) return NotFound();
                if (string.IsNullOrWhiteSpace(usr.Username) || usr.Password.Count() < 4) return BadRequest("Check credentials.");
                if (Users.Any(u => u.Username == usr.Username)) return BadRequest("User already Exists.");
                Users.Add(usr);
                return Ok(usr);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // user login
        [HttpPost]
        [RouteAttribute("user/login")]
        public IHttpActionResult Login([FromBody] User usr)
        {
            try
            {
                if (usr == null) return NotFound();
                if (string.IsNullOrWhiteSpace(usr.Username) || usr.Password.Count() < 4) return BadRequest("Check credentials.");
                string jwtToken = JWTHelper.GenerateToken(usr.Username);

                return Ok(new { message = "Login successful.", token = jwtToken });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
