using E_Commerce.Models.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.Products
{
    public class UpdateProductModel
    {

        [Key]

        public int Id { get; set; }

       
        [StringLength(20)]

       
        public string Name { get; set; }
        [StringLength(200)]
       
        public string Describtion { get; set; }
      
        
        public float Price { get; set; }

        public int categoryId { get; set; }

        public IFormFile PhotoPath { get; set; }
    }
}
