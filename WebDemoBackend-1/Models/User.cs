using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemoBackend_1.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public List<Book> purchasedBooks = new List<Book>();
    }
}