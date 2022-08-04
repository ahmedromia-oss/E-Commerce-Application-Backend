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

namespace E_Commerce.Controllers
{

    [Authorize(Roles = "Admin",AuthenticationSchemes = "Bearer")]
    
    public class CategoryController : Controller
    {
        private readonly AppDBContext appDBContext;

        public CategoryController(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return Ok(this.appDBContext.categories);
        }
        [HttpPost]
        public IActionResult create(Category category)
        {
            if (ModelState.IsValid)
            {
                if (this.appDBContext.categories.Any(e => e.Name == category.Name))
                {
                    ModelState.AddModelError("Name", "Must be Unique Value");
                    return BadRequest(ModelState);
                }
                Category category1 = new Category()
                {
                    Name = category.Name,
                    Describtion = category.Describtion
                };

                this.appDBContext.categories.Add(category1);
                this.appDBContext.SaveChanges();
                return Ok(category1);
            }
            else
            {
                return BadRequest(ModelState);
            }
          
        }
        [HttpPut]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
        public IActionResult Edit(int id, UpdateCategory category)
        {
            Category categoryt1 = this.appDBContext.categories.FirstOrDefault(e => e.Id == id);


            if (!this.appDBContext.categories.Any(e => e.Id == id))
            {
                ModelState.AddModelError("category", "category Not Found");
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {

                if (this.appDBContext.categories.Any(e => e.Name == category.Name && category.Name != this.appDBContext.categories.FirstOrDefault(e => e.Id == id).Name))
                {
                    ModelState.AddModelError("Name", "Must be Unique Value");
                    return BadRequest(ModelState);
                }

                else
                {
                    var result =

                    categoryt1.Name = category.Name == null ? categoryt1.Name : category.Name;
                   
                    categoryt1.Describtion = category.Describtion == null ? categoryt1.Describtion : category.Describtion;
                    this.appDBContext.categories.Update(categoryt1);
                    this.appDBContext.SaveChanges();
                }
                return Ok(categoryt1);


            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            Category result = appDBContext.categories.FirstOrDefault<Category>(e => e.Id == id);
            if(result == null)
            {
                return BadRequest(new { Error = "Category Not Found" });
            }
            else
            {
                appDBContext.categories.Remove(result);
                appDBContext.SaveChanges();
                return Ok(result);
            }
            
           
        }
    }

}
