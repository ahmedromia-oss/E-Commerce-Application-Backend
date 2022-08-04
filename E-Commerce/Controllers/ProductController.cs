using E_Commerce.Models.DataBase;
using E_Commerce.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using E_Commerce.Models.Categories;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Models;
using E_Commerce.Models.Users;
//using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
   
    //[AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProduct _iproduct;
        private AppDBContext appDBContext;
        private readonly RoleManager<IdentityRole> roleManager;

        public ProductController(IProduct iproduct , AppDBContext appDBContext , RoleManager<IdentityRole> roleManager)
        {
            _iproduct = iproduct;
            this.appDBContext = appDBContext;
            this.roleManager = roleManager;
        }
        [HttpGet]
       
        // GET: ProductController
       
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return Ok(new { this.appDBContext.Products, FeedBack = this.appDBContext.feedBackUsers.Include(e=>e.user).FirstOrDefault(e => e.user.UserName == User.Identity.Name) });
            //return ("Hello from the api");
        }

        [HttpGet]
        [Authorize(Roles = "Admin , costumer", AuthenticationSchemes = "Bearer")]
        public IActionResult Details(int id)
        {
            if (this.appDBContext.Products.Any(e => e.Id == id))
            {
                var UserName = User.Identity.Name;
               
                Product product = this.appDBContext.Products.FirstOrDefault<Product>(e => e.Id == id);
                return Ok(new { product, FeedBack = this.appDBContext.feedBackUsers.Where(e => e.user.UserName== User.Identity.Name && e.product == product).Select(e=>e.feedBack)});
            }
            else
            {
                ModelState.AddModelError("Product", "Product Not Found");
                return BadRequest(ModelState);
            }
           
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public IActionResult Create(ProductViewModel product ,int id)
        {
            
            
            
            if (ModelState.IsValid)
            {
                if (this.appDBContext.Products.Any(e => e.Name == product.Name))
                {
                    ModelState.AddModelError("Name", "Must be Unique Value");
                    return BadRequest(ModelState);
                }
                if(!this.appDBContext.categories.Any(e => e.Id == id))
                {
                    ModelState.AddModelError("Category", "Category Not Found");
                    return BadRequest(ModelState);
                }
                else
                {
                    return Ok(new {product =  _iproduct.CreateProduct(product, id) });
                }

                
            }
            return BadRequest(ModelState);
            
        }
      
      
        
        [HttpPut]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public IActionResult Edit(int id , UpdateProductModel product)
        {
            Product product1 = this.appDBContext.Products.Include(e=>e.category).FirstOrDefault(e => e.Id == id);
          

            if (!this.appDBContext.Products.Any(e=>e.Id == id))
            {
                ModelState.AddModelError("Product", "Product Not Found");
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                
                if (this.appDBContext.Products.Any(e => e.Name == product.Name && product.Name != this.appDBContext.Products.FirstOrDefault(e=>e.Id == id).Name))
                {
                    ModelState.AddModelError("Name", "Must be Unique Value");
                    return BadRequest(ModelState);
                }
               
                else
                {
                    var result = 
                   
                    product1.Name = product.Name == null? product1.Name : product.Name;
                    product1.category = !this.appDBContext.categories.Any(e => e.Id == product.categoryId) ? product1.category : this.appDBContext.categories.FirstOrDefault(e => e.Id == product.categoryId);
                    product1.Price = product.Price == 0? product1.Price: product.Price ;
                    product1.Describtion = product.Describtion == null ? product1.Describtion: product.Describtion ;
                    this.appDBContext.Products.Update(product1);
                    this.appDBContext.SaveChanges();
                }
                return Ok(product1);


            }
            return BadRequest(ModelState);
        }

        // GET: ProductController/Delete/5
        

        // POST: ProductController/Delete/5
        [HttpDelete]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public IActionResult Delete(int id)
        {
            if(this.appDBContext.Products.Any(e=>e.Id == id))
            {
                return Ok(_iproduct.DeltePRoduct(id));
            }
            else
            {
                return BadRequest(new { Error = "Product IS not Found" });
            }
           
        }

        [HttpPut]
        [Authorize(Roles = "Admin, costumer" ,  AuthenticationSchemes = "Bearer")]
        public IActionResult GiveFeedBack(int id , FeedBackUser feedBackuser)
        {
            var calc = "";
            if (ModelState.IsValid)
            {
                if (!this.appDBContext.Products.Any(e => e.Id == id))
                {
                    ModelState.AddModelError("Product", "Product Not Found");
                    return BadRequest(ModelState);
                }

                var UserName = User.Identity.Name;
                User user = this.appDBContext.Users.FirstOrDefault<User>(e => e.Email == UserName);
                Product product = this.appDBContext.Products.FirstOrDefault(e => e.Id == id);
                var FeedBackProduct = this.appDBContext.feedBackUsers.FirstOrDefault(e => e.user.UserName == UserName && e.product.Id == id);


                if (FeedBackProduct == null)
                {
                    FeedBackUser feedBackUser = new FeedBackUser()
                    {
                        user = user,
                        product = product,
                        feedBack = feedBackuser.feedBack
                    };
                    product.NumberOfFeedBacks += 1;
                    product.FeedBack = ((product.FeedBack * (product.NumberOfFeedBacks - 1)) + feedBackuser.feedBack) / product.NumberOfFeedBacks;
                    
                    this.appDBContext.Products.Update(product);
                    this.appDBContext.SaveChanges();

                    this.appDBContext.feedBackUsers.Add(feedBackUser);
                    this.appDBContext.SaveChanges();

                }
                else
                {

                    if (product.NumberOfFeedBacks > 1)
                    {



                        product.FeedBack = ((product.FeedBack * product.NumberOfFeedBacks) - FeedBackProduct.feedBack) / (product.NumberOfFeedBacks - 1);
                        FeedBackProduct.feedBack = feedBackuser.feedBack;
                        this.appDBContext.Products.Update(product);
                        this.appDBContext.feedBackUsers.Update(FeedBackProduct);
                       
                        this.appDBContext.SaveChanges();
                        FeedBackProduct.feedBack = feedBackuser.feedBack;
                        product.FeedBack = ((product.FeedBack * (product.NumberOfFeedBacks - 1)) + feedBackuser.feedBack) / product.NumberOfFeedBacks;
                        this.appDBContext.Products.Update(product);
                        this.appDBContext.feedBackUsers.Update(FeedBackProduct);
                        this.appDBContext.SaveChanges();
                    }
                    else
                    {
                        FeedBackProduct.feedBack = feedBackuser.feedBack;
                        product.FeedBack = ((product.FeedBack * (product.NumberOfFeedBacks - 1)) + feedBackuser.feedBack) / product.NumberOfFeedBacks;
                        this.appDBContext.Products.Update(product);
                        this.appDBContext.feedBackUsers.Update(FeedBackProduct);
                        this.appDBContext.SaveChanges();
                    }
                    
                 
                   



                }
                return Ok(new { product, calc = calc});
            }
          
            return BadRequest(ModelState);
            
         
           
        }

        
    }
}
