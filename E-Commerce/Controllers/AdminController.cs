using E_Commerce.Models;
using E_Commerce.Models.DataBase;
using E_Commerce.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
   
    
    public class AdminController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppDBContext appDBContext;
        private readonly UserManager<User> userManager;

        public AdminController(RoleManager<IdentityRole> roleManager , AppDBContext appDBContext , UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.appDBContext = appDBContext;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return Ok();
        }
      [HttpPost]
        public async Task<IActionResult> AddUserToRole(string Email)
        {
            var user = this.appDBContext.Users.FirstOrDefault(e => e.Email == Email);
            var role = await roleManager.FindByNameAsync("Admin");
            
            if (user != null)
            {
                if (await userManager.IsInRoleAsync(user , role.Name))
                {
                    return Ok(new { message = "the user is already in the Role" });
                }
                else
                {
                    var result = await userManager.AddToRoleAsync(user, role.Name);
                    
                    return Ok(user);
                }
                
            }
            ModelState.AddModelError("Error", "There is no user with the Email" + Email);
            return BadRequest(ModelState);

        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = roleModel.RoleName,
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return Ok(identityRole);
                }
            }
            return BadRequest(ModelState);
            
        }









        }
    }

