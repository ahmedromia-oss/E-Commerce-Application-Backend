using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Models.Carts;
using E_Commerce.Models.Products;

namespace E_Commerce.Models.ProductCarts
{
    public class ProductCart
    {
        [Key]
        public int Id { get; set; }
        
        public Cart cart { get; set; }
     
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}
