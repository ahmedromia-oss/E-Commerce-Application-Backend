using E_Commerce.Models.Carts;
using E_Commerce.Models.DataBase;
using E_Commerce.Models.ProductCarts;
using E_Commerce.Models.Products;
using E_Commerce.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Admin , costumer", AuthenticationSchemes = "Bearer")]
    public class CartController : Controller
    {
        private AppDBContext appDBContext;
        
        private readonly UserManager<User> userManager;

        public CartController(AppDBContext appDBContext , UserManager<User> userManager)
        {
            this.appDBContext = appDBContext;
            
            this.userManager = userManager;
            
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var UserName = User.Identity.Name;
            User user = this.appDBContext.Users.Include(e => e.cart).FirstOrDefault<User>(e => e.Email == UserName);

            Cart carts = this.appDBContext.Carts.FirstOrDefault<Cart>(e => e.Id == user.cart.Id);


            var result = this.appDBContext.ProductCarts.Include(e => e.product).Where(e => e.cart == carts).Select(e => new { e.product , e.Quantity});

           

            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddProduct(int id)
        {
            if (this.appDBContext.Products.Any<Product>(e => e.Id == id))
            {


                var UserName = User.Identity.Name;
                User user = this.appDBContext.Users.Include(e => e.cart).FirstOrDefault<User>(e => e.Email == UserName);

                Product result = this.appDBContext.Products.FirstOrDefault<Product>(e => e.Id == id);
                Cart cart = this.appDBContext.Carts.FirstOrDefault<Cart>(e => e.Id == user.cart.Id);

                if (this.appDBContext.ProductCarts.FirstOrDefault(e => e.cart == cart && e.product == result) != null)
                {
                    ProductCart productCart = this.appDBContext.ProductCarts.FirstOrDefault(e => e.cart == cart && e.product == result);
                    productCart.Quantity = productCart.Quantity + 1;
                    cart.price = cart.price + result.Price;
                    this.appDBContext.SaveChanges();
                    return Json(productCart);
                }

                else
                {
                    ProductCart productCart1 = new ProductCart()
                    {
                        cart = cart,
                        product = result,
                        Quantity = 1,
                    };
                    this.appDBContext.ProductCarts.Add(productCart1);
                    cart.price = cart.price + result.Price;
                    this.appDBContext.SaveChanges();
                    return Json(productCart1);
                }
            }
            else
            {
                return NotFound(new { Error = "Product Not Found" });
            }
        }
        [HttpPost]
        public IActionResult create()
        {
            Cart cart1 = new Cart()
            {
                price = 0
            };
            this.appDBContext.Carts.Add(cart1);
            this.appDBContext.SaveChanges();
            return Json(cart1);
        }
        [HttpPost]
        public IActionResult RemoveProductByOne(int id)
        {
            if (this.appDBContext.Products.Any<Product>(e => e.Id == id))
            {


                var UserName = User.Identity.Name;
                User user = this.appDBContext.Users.Include(e => e.cart).FirstOrDefault<User>(e => e.Email == UserName);

                Product result = this.appDBContext.Products.FirstOrDefault<Product>(e => e.Id == id);
                Cart cart = this.appDBContext.Carts.FirstOrDefault<Cart>(e => e.Id == user.cart.Id);

                if (this.appDBContext.ProductCarts.FirstOrDefault(e => e.cart == cart && e.product == result) != null)
                {
                    
                    ProductCart productCart = this.appDBContext.ProductCarts.FirstOrDefault(e => e.cart == cart && e.product == result);
                    productCart.Quantity = productCart.Quantity - 1;
                    cart.price = cart.price - result.Price;
                    if (productCart.Quantity == 0)
                    {
                        this.appDBContext.Remove(productCart);
                        this.appDBContext.SaveChanges();
                        return Ok(productCart);

                    }
                   
                    this.appDBContext.SaveChanges();
                    return Ok(productCart);
                }
                

                
            }
          
            return NotFound(new { Error = "Product Not Found" });
            
        }
        [HttpDelete]
        public IActionResult RemoveProduct(int id)
        {
            if (this.appDBContext.Products.Any<Product>(e => e.Id == id))
            {


                var UserName = User.Identity.Name;
                User user = this.appDBContext.Users.Include(e => e.cart).FirstOrDefault<User>(e => e.Email == UserName);

                Product result = this.appDBContext.Products.FirstOrDefault<Product>(e => e.Id == id);
                Cart cart = this.appDBContext.Carts.FirstOrDefault<Cart>(e => e.Id == user.cart.Id);

                

                ProductCart productCart = this.appDBContext.ProductCarts.FirstOrDefault(e => e.cart == cart && e.product == result);
                cart.price = cart.price - (productCart.Quantity * result.Price);
                    
                    
                this.appDBContext.Remove(productCart);
                this.appDBContext.SaveChanges();
                return Ok(cart);
            }

            return NotFound(new { Error = "Product Not Found" });

        }
    }
}
