using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Blog_Ozan.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}