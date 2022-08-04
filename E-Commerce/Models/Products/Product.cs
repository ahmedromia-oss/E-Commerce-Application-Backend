using E_Commerce.Models.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.Products
{
    public class Product
    {
        [Key]
        
        public int Id { get; set; }
       
        
        public string Name { get; set; }
       
      
        public string Describtion { get; set; }
        
        public float Price { get; set; }
       
        public float FeedBack { get; set; }
       
       
        public int NumberOfFeedBacks {  get; set; }
        public Category category { get; set; }

        public string PhotoPath { get; set; }
     
    }
}
