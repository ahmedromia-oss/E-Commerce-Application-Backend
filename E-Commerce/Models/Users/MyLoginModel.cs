using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.Users
{
    public class MyLoginModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
