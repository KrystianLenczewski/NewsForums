using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NewsForums.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsForums.Data
{
    

    public class DataSeeder
    {
        private ApplicationDbContext _context;
        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }
        public  Task SeedSuperUser()
        {
            
            var user = new ApplicationUser
            {
                UserName = "Admin",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),

            };

            var store = new RoleStore<IdentityRole>(_context);
            var userStore = new UserStore<ApplicationUser>(_context);
            
            
            var hasher = new PasswordHasher<ApplicationUser>();
            var hashedPassword = hasher.HashPassword(user, "admin");

            user.PasswordHash = hashedPassword;


                var hasAdminRole=_context.Roles.Any(roles=>roles.Name=="admin");
            if(!hasAdminRole)
            {
                 store.CreateAsync(new IdentityRole {Name="admin",NormalizedName="admin" });
            }
            var hasSuperUser = _context.Users.Any(u => u.NormalizedUserName == user.UserName);
        if(!hasSuperUser)//if it doesn't have
            {
                 userStore.CreateAsync(user);
                 userStore.AddToRoleAsync(user, "admin");
            }
             _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }
}
