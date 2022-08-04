using E_Commerce.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.Orders
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public float price { get; set; }
        public User user { get; set; }
        public DateTime OrderRequestedDate { get; set; }
        public DateTime DelivreyDate { get; set; }
        [Required]
        public string Address { get; set; }
        public int FeedBack { get; set; }
       
    }
}
