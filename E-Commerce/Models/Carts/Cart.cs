using E_Commerce.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.Carts
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
       
        public float price { get; set; }
    }
}
