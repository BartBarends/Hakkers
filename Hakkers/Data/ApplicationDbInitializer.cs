using Hakkers.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//TODO: In the Startup.cs file,
//      in the configure method,
//      after: app.UseAuthentication(); 
//      add: ApplicationDbInitializer.Seed(roleManager, userManager);

namespace Hakkers.Data
{
    public static class ApplicationDbInitializer
    {
        private static readonly string _roleName = "Admin";
        private static readonly string _email = "developer@application.com";
        private static readonly string _password = "Password1!";
        private static readonly string _phoneNumber = "";

        private static readonly IdentityUser _identityUser = new IdentityUser
        {
            UserName = _email,
            NormalizedUserName = _email.ToUpper(),
            Email = _email,
            NormalizedEmail = _email.ToUpper(),
            EmailConfirmed = false,
            //PasswordHash = new PasswordHasher<>,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            PhoneNumber = _phoneNumber,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = true,
            AccessFailedCount = 0,
        };

        public static async void Seed(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            //TODO: Run Update-DataBase in Package Manager Console to create database before running the application for the first time.
            await SeedRole(roleManager);
            await SeedUser(userManager);
            await SeedUserRoles(userManager);
            //await SeedAssignmentCategories(context);
        }

        //private static void SeedAssignmentCategories(object context)
        //{
        //    //bool assignment_CategoryExists = context.;

        //    List<string> AssignmentCategories = new List<string> 
        //    {
        //        { "Gas"  },
        //        { "Water"  },
        //        { "Electricity" },
        //    };

        //    foreach (var item in AssignmentCategories)
        //    {
        //        //context.add
        //    }

        //    if (true) //assignment_CategoryExists == false
        //    {
        //        //await roleManager.CreateAsync(new IdentityRole { Name = _roleName });
        //    }
        //}

        public static async Task SeedRole(RoleManager<IdentityRole> roleManager)
        {
            bool roleExists = roleManager.RoleExistsAsync(_roleName).Result;

            if (roleExists == false)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = _roleName });
            }
        }

        public static async Task SeedUser(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync(_email).Result == null)
            {
                IdentityResult result = userManager.CreateAsync(_identityUser, _password).Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(_identityUser, _roleName);
                }
            }
        }

        private static async Task SeedUserRoles(UserManager<IdentityUser> userManager)
        {
            bool isAdmin = false;
            var user = await userManager.FindByEmailAsync(_email);

            var rolesList = await userManager.GetRolesAsync(_identityUser);
            if (rolesList.Count == 0)
            {
                _ = await userManager.AddToRoleAsync(user, _roleName);
            }
            else
            {
                foreach (var role in rolesList)
                {
                    if (role == _roleName)
                    {
                        isAdmin = true;
                    }
                }
                if (isAdmin == false)
                {
                    _ = await userManager.AddToRoleAsync(user, _roleName);
                }
            }
        }
    }
}