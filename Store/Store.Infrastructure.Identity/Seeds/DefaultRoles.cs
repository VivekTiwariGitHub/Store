using Microsoft.AspNetCore.Identity;
using Store.Application.Enums;
using Store.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Privileged.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Normal.ToString()));
        }
    }
}
