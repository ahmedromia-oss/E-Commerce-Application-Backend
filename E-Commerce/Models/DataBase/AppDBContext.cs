using E_Commerce.Models.Carts;
using E_Commerce.Models.Categories;
using E_Commerce.Models.Orders;
using E_Commerce.Models.ProductCarts;
using E_Commerce.Models.ProductOrders;
using E_Commerce.Models.Products;
using E_Commerce.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.DataBase
{
    public class AppDBContext : IdentityDbContext<User>
    {
    

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
          
           
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string costumer_ID = "02174cf0–9412–4cfe-afbf-59f806d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "costumer",
                NormalizedName = "COSTUMER",
                Id = costumer_ID,
                ConcurrencyStamp = costumer_ID
            });

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
                
            });

            

            //create user
            var appUser = new User
            {
                Id = ADMIN_ID,
                Email = "Admin@gmail.com",
                EmailConfirmed = true,
               
                UserName = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
            
            };

            //set user password
            PasswordHasher<User> ph = new PasswordHasher<User>();
            appUser.PasswordHash = ph.HashPassword(appUser, "@Dmin123");

            //seed user
            builder.Entity<User>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        
          
            if (builder == null)
                throw new ArgumentNullException("modelBuilder");

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                   
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Cascade);
            }

            base.OnModelCreating(builder);
        }

    

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }
        public DbSet<ProductOrder> productOrders { get; set; }
        public DbSet<Category> categories{ get; set; }
        public DbSet<FeedBackUser> feedBackUsers { get; set; }



    }
}
