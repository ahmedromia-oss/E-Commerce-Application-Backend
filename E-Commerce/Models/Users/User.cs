using E_Commerce.Models.Carts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.Users
{
    public class User : IdentityUser
    {
        public Cart cart { get; set; }
    }
}
