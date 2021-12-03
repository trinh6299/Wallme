using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Wallme_Web_API.Models
{
    public class User : IdentityUser<int>
    {
        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public ICollection<Cart> Carts { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}