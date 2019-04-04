
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppCore.Data.EFContext
{
    public class EFContext
    {





        public class ShopContext : IdentityDbContext<ApplicationUser>
        {

        
            public ShopContext(DbContextOptions<ShopContext> options)
                : base(options)
            {
 
                
            }

            public ShopContext(string connectionString) : base(GetOptions(connectionString))
            {
            }

            private static DbContextOptions GetOptions(string connectionString)
            {
                return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            }



            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }

            public DbSet<BankAppCore.Models.Bill> Bills { get; set; }

            public DbSet<BankAppCore.Models.Client> Clients { get; set; }

            public DbSet<BankAppCore.Models.Account> Accounts { get; set; }

            public DbSet<BankAppCore.Models.UserActionLog> UserActionLogs { get; set; }
        }
    }
}
