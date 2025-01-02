using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDemoBackend_1.Controllers
{
    public class BookIssueController : Controller
    {
        // add books to a list(try ascending ordering)


        // GET: get list of books present in library.
        public ActionResult Index()
        {
            return View();
        }

        // GET: get list of books for a user by his header's jwt token
 
 
    }
}