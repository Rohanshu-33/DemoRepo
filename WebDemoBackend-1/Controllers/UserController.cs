using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Results;
using WebDemoBackend_1.Models;
using WebDemoBackend_1.Helpers;

namespace WebDemoBackend_1.Controllers
{
    public class UserController : ApiController
    {
        private static readonly List<User> Users = new List<User>();

        // user signup
        [HttpPost]
        [Route("users/signup")]
        public IHttpActionResult Signup([FromBody] User usr)
        {
            try
            {
                if (usr == null) return NotFound();
                if (usr.username.IsNullOrWhiteSpace() || usr.password.Count() < 4) return BadRequest("Check credentials.");
                if (Users.Any(u => u.username == usr.username)) return BadRequest("User already Exists.");
                Users.Add(usr);
                return Ok(usr);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // user login
        [HttpPost]
        [RouteAttribute("users/login")]
        public IHttpActionResult Login([FromBody] User usr)
        {
            try
            {
                if (usr == null) return NotFound();
                if (usr.username.IsNullOrWhiteSpace() || usr.password.Count() < 4) return BadRequest("Check credentials.");
                string jwtToken = JWTHelper.GenerateToken(usr.username);

                // Set response cache control header
                Response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue
                {
                    Public = true,  // Allow public caching (can be cached by intermediate proxies)
                    MaxAge = TimeSpan.FromHours(1)  // Cache for 1 hour
                };

                // Alternatively, you can use the older Response.Cache method for more fine-grained control
                Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);  // Public cache
                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(1));  // Expire in 1 hour
                Response.Cache.SetMaxAge(TimeSpan.FromHours(1));  // Max cache age
                return Ok(new { message= "Login successful.", token= jwtToken});
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}