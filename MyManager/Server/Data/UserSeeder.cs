using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyManager.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Data
{
    public class UserSeeder
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UserSeeder(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async void SeedUser()
        {
            var user = new ApplicationUser
            {
                //Email = "cockshit.com@gmail.com",
                //UserName = "gauravdhungana77@gmail.com",
                //NormalizedUserName = "gauravdhungana77@gmail.com",
                //NormalizedEmail = "gauravdhungana77@gmail.com",
                Email = "cockshit.com@gmail.com",
                UserName = "cockshit.com@gmail.com",
                NormalizedUserName = "cockshit.com@gmail.com",
                NormalizedEmail = "cockshit.com@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "testT!1");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(context);
                await userStore.CreateAsync(user);
            }

            await context.SaveChangesAsync();
        }
    }
}
