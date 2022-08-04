using E_Commerce.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using E_Commerce.Models.Carts;

namespace E_Commerce.Models.DataBase
{
    public class SeedData
    {
        public static void Seed(AppDBContext appDBContext)
        {
            Cart cart = new Cart()
            {
                price = 0
            };
            appDBContext.Carts.Add(cart);
            appDBContext.SaveChanges();

            var user = appDBContext.Users.FirstOrDefault(e => e.Id == "02174cf0–9412–4cfe-afbf-59f706d72cf6");
            user.cart = cart;
            appDBContext.Users.Update(user);
            appDBContext.SaveChanges();
        }
        
       


        }
    }


        