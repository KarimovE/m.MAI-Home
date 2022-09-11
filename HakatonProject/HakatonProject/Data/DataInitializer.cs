using HackatonProject.DataAccessLayer;
using HackatonProject.Models;
using HackatonProject.DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HackatonProject.Data
{
    public class DataInitializer
    {
        public readonly AppDbContext _dbContext;

        public readonly RoleManager<IdentityRole> _roleManager;
        
        public readonly UserManager<User> _userManager;

        public DataInitializer(AppDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _dbContext = dbContext;

            _roleManager = roleManager;
            
            _userManager = userManager;
        }

        public async Task SeedDataAsync()
        {
            await _dbContext.Database.MigrateAsync();

            var roles = new List<string>()
            {
                RoleConstants.UserRole
            };

            foreach (var role in roles)
            {
                if (await _roleManager.RoleExistsAsync(role))

                    continue;

                await _roleManager.CreateAsync(new IdentityRole(role));
            }

            var userUser = new User
            {
                FullName = "Admin Admin",
                UserName = "Admin",
                Email = "admin@code.az",
            };


            if (await _userManager.FindByNameAsync(userUser.UserName) != null)
                return;


            await _userManager.CreateAsync(userUser, "Admin748159263@");
            await _userManager.AddToRoleAsync(userUser, RoleConstants.UserRole);

        }
    }
}
