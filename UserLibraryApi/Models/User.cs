using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserLibraryApi.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Book> purchasedBooks = new List<Book>();
    }
}