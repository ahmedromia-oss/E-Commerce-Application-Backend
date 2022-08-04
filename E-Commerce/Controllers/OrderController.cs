using E_Commerce.Models.DataBase;
using E_Commerce.Models.Orders;
using E_Commerce.Models.ProductCarts;
using E_Commerce.Models.ProductOrders;
using E_Commerce.Models.Products;
using E_Commerce.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Admin , costumer", AuthenticationSchemes = "Bearer")]
    public class OrderController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly AppDBContext appDBContext;

        public OrderController(UserManager<User> userManager , SignInManager<User> signInManager , AppDBContext appDBContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            var UserName = User.Identity.Name;
            User user = this.appDBContext.Users.FirstOrDefault<User>(e => e.Email == UserName);

            var result = this.appDBContext.Orders.Include(e=>e.user).Where(e => e.user.Id == user.Id).Select(e => new {e.Id , e.OrderRequestedDate , e.DelivreyDate, e.price});

            return Ok(result);


        }
        [HttpPost]
        public IActionResult create()
        {
            var UserName = User.Identity.Name;
            User user = this.appDBContext.Users.Include(e => e.cart).FirstOrDefault<User>(e => e.Email == UserName);

            var products = this.appDBContext.ProductCarts.Include(e => e.product).Where(e => e.cart.Id == user.cart.Id );
            List<ProductCart> products1 = new List<ProductCart>();
            if (products.Any())
            {


                Order order = new Order()
                {
                    price = user.cart.price,
                    user = user,
                    OrderRequestedDate = DateTime.Now

                };
                this.appDBContext.Orders.Add(order);
                this.appDBContext.SaveChanges();
                foreach (ProductCart product in products)
                {
                    products1.Add(product);
                }
                foreach (ProductCart product1 in products1)
                {
                    ProductOrder productOrder = new ProductOrder()
                    {
                        Order = order,
                        Product = product1.product,
                        Quantity = product1.Quantity



                    };
                    this.appDBContext.productOrders.Add(productOrder);
                    this.appDBContext.SaveChanges();
                }

                return Ok(new {order.price , order.Id , order.user.UserName });
            }
            else
            {
                return BadRequest(new { Error = "Your cart is empty" });
            }
        }

        public IActionResult Order(int id)
        {
            var UserName = User.Identity.Name;

            User user = this.appDBContext.Users.FirstOrDefault<User>(e => e.Email == UserName);

            var result = this.appDBContext.Orders.Include(e=>e.user).FirstOrDefault(e => e.Id == id);
            if(user.UserName == result.user.UserName)
            {
                return Ok(this.appDBContext.productOrders.Include(e => e.Product).Where(e => e.Order.Id == id).Select(e=> new {e.Product , e.Quantity }));
            }

            return NotFound();
        }
    }
}
