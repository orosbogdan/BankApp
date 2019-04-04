using BankAppCore.Data.EFContext;
using BankAppCore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BankAppCore.Data.EFContext.EFContext;

namespace BankAppCore.Data
{
    public class DatabaseSeeder
    {

        public static void Initialize(ShopContext context, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
  
           
            if (!context.Roles.Any())
            {
                IdentityRole role = new IdentityRole
                {
                    Id="0",
                    Name="Admin",
                    ConcurrencyStamp=null,
                    NormalizedName="admin"
                };
                IdentityRole employee = new IdentityRole
                {
                    Id = "1",
                    Name = "Employee",
                    ConcurrencyStamp = null,
                    NormalizedName = "employee"
                };
                context.Roles.Add(employee);
                context.Roles.Add(role);
                context.SaveChanges();
            }


            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "abc@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Ram",
                    RegisterDate = DateTime.Now
                };

                userManager.CreateAsync(user, "!Bogdan18").Wait();

                IdentityUserRole<string> userRole = new IdentityUserRole<string>();
                userRole.RoleId = "1";
                userRole.UserId = context.Users.Single(x => x.UserName == "Ram").Id;
                context.UserRoles.Add(userRole);


                ApplicationUser admin = new ApplicationUser()
                {
                    Email = "orosbogdan@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "orosbogdan@gmail.com",
                    RegisterDate = DateTime.Now
                };

                userManager.CreateAsync(admin, "!Bogdan18").Wait();

                IdentityUserRole<string> userAdmin = new IdentityUserRole<string>();
                userAdmin.RoleId = "0";
                userAdmin.UserId = context.Users.Single(x => x.UserName == "orosbogdan@gmail.com").Id;
                context.UserRoles.Add(userRole);

                context.SaveChanges();
            }

            if (!context.Clients.Any())
            {
                Client c1 = new Client();
                c1.FirstName = "Bogdan";
                c1.LastName = "Oros";
                c1.IdentityCardNumber = "SM200232";
                c1.Address = "Mehedinti";
                c1.SocialSecurityNumber = "11111111";

                Client c2 = new Client();
                c2.FirstName = "Ovidiu";
                c2.LastName = "Oros";
                c2.IdentityCardNumber = "SM333232";
                c2.Address = "Manastur";
                c2.SocialSecurityNumber = "11111122";

                context.Clients.Add(c1);
                context.SaveChanges();
                context.Clients.Add(c2);

                context.SaveChanges();
            }

            if (!context.Accounts.Any())
            {
                Account a1 = new Account();
                a1.Amount = 111;
       
                a1.Type = 0;
                a1.CreationDate = DateTime.Now;
                a1.Client = context.Clients.Single(x => x.SocialSecurityNumber == "11111122");

                Account a2 = new Account();
                a2.Amount = 222;
         
                a2.Type = 0;
                a2.CreationDate = DateTime.Now;
                a2.Client = context.Clients.Single(x => x.SocialSecurityNumber == "11111111");


                Account a3 = new Account();
                a3.Amount = 333;
          
                a3.Type = 0;
                a3.CreationDate = DateTime.Now;
                a3.Client = context.Clients.Single(x => x.SocialSecurityNumber == "11111111");


                context.Accounts.Add(a1);
                context.SaveChanges();
                context.Accounts.Add(a2);
                context.SaveChanges();
                context.Accounts.Add(a3);
                context.SaveChanges();
            }



        }
    }
}
