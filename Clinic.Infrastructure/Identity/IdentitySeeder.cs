using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Identity
{
    public static class IdentitySeeder
    {
        public static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Doctor", "Nurse", "Receptionist","Patient" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
