using E_Commerce.Models.Orders;
using E_Commerce.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.ProductOrders
{
    public class ProductOrder
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }

    }
}
