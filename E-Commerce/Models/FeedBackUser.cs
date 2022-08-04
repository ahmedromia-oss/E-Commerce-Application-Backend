using E_Commerce.Models.Products;
using E_Commerce.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class FeedBackUser
    {
        [Key]
        public int Id { get; set; }
        public User user { get; set; }
        public Product product { get; set; }
        [Required]
        [Range(0 , 5)]
        public float feedBack { get; set; }
    }
}
