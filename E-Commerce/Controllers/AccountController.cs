using E_Commerce.Models.Carts;
using E_Commerce.Models.DataBase;
using E_Commerce.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
   
    public class AccountController : Controller
    {
        
        private readonly UserManager<User> userManger;
        private readonly SignInManager<User> signInManager;
        private readonly AppDBContext appDBContext;
      
        public AccountController(UserManager<User> userManger , SignInManager<User> signInManager , AppDBContext appDBContext)
        {
            this.userManger = userManger;
            this.signInManager = signInManager;
            this.appDBContext = appDBContext;
        }
        [HttpPost]
        
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {



                User user = new User()
                {
                    Email = registerUser.Email,
                    UserName = registerUser.Email,
                    EmailConfirmed = false,

                };
                
                var result = await userManger.CreateAsync(user, registerUser.ConfirmPassWord);
                await userManger.AddToRoleAsync(user, "Costumer");
                if (result.Succeeded)
                {
                    Cart cart1 = new Cart()
                    {
                        price = 0
                    };

                    this.appDBContext.Carts.Add(cart1);
                    this.appDBContext.SaveChanges();

                    user.cart = cart1;
                    this.appDBContext.SaveChanges();


                    return Ok(new { Result = "Register Success" });

                }
                
            }
            return BadRequest(ModelState);
           
            
        }
        [HttpPost]
        


        public async Task<IActionResult> Login([FromBody] MyLoginModel myLoginModel)
        {
            if (ModelState.IsValid)
            {


                var user = appDBContext.Users.FirstOrDefault(x => x.Email == myLoginModel.Email);

                if (user != null)
                {

                    var signInResult = await signInManager.CheckPasswordSignInAsync(user, myLoginModel.password, false);
                    if (signInResult.Succeeded)
                    {

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes("MY-BIG-SECRET-KEY");
                        var role = await userManger.GetRolesAsync(user);
                        IdentityOptions options = new IdentityOptions();

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                    new Claim(ClaimTypes.Name, myLoginModel.Email.ToString()),
                    new Claim(options.ClaimsIdentity.RoleClaimType , role.FirstOrDefault()),

                            }),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var tokenString = tokenHandler.WriteToken(token);

                        // return basic user info and authentication token
                        return Ok(new { Token = tokenString });
                    }
                    else
                    {
                        ModelState.AddModelError("password", "Check Your password");
                    }

                }
                else
                {
                    ModelState.AddModelError("Email", "Check Your Email");
                }
            }
            return BadRequest(ModelState);

        }
        [Authorize(Roles = "Admin , costumer", AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            if (signInManager.SignOutAsync().IsCompleted)
            {
                return Ok(new { Result = "Signed out succefully" });
            }
            return BadRequest(new { Result = "Sign Out failed" });
           
        }




    }
    
}
