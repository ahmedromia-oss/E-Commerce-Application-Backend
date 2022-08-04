using E_Commerce.Models.Categories;
using E_Commerce.Models.CustomValidation;
using E_Commerce.Models.DataBase;
using E_Commerce.Models.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.Products
{
    public class ProductViewModel
    {
        

       

        
      
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        
       [UniqueName()]
        public string Name { get; set; }
        [StringLength(200)]
        [Required]
        public string Describtion { get; set; }
        [Required]
        [Range(1 , Int32.MaxValue , ErrorMessage = "Must be more than 0")]
        public float Price { get; set; }
        
        public Category category { get; set; }

        public IFormFile PhotoPath { get; set; }
        

    }


   
}

