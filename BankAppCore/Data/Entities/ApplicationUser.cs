using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppCore.Data.EFContext
{
    public class ApplicationUser : IdentityUser, IUser
    {
        public DateTime RegisterDate { get; set; }
    }
}
