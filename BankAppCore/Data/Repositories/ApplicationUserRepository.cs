using BankAppCore.Data.EFContext;
using BankAppCore.DataTranferObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAppCore.Data.Repositories
{
    public class ApplicationUserRepository 
    {
        private EFContext.EFContext.ShopContext context;
        private UserManager<ApplicationUser> userManager;

        private bool disposed = false;

        public ApplicationUserRepository(EFContext.EFContext.ShopContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
        }

        public IEnumerable<ApplicationUser> Get()
        {
            return context.Users.ToList();
        }

        public ApplicationUser GetByID(string id)
        {
            return context.Users.Find(id);
        }

        public  void Insert(ApplicationUser entity, string password)
        {      
            userManager.CreateAsync(entity, password).Wait();
        }

        public void Update(PasswordChangeModel passwordChangeModel)
        {
            ApplicationUser user = context.Users.Find(passwordChangeModel.Id);

            userManager.ChangePasswordAsync(user, passwordChangeModel.OldPassword, passwordChangeModel.NewPassword).Wait();

            user.UserName = passwordChangeModel.Username;
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            ApplicationUser applicationUser = context.Users.Find(id);

            userManager.DeleteAsync(applicationUser).Wait();

        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
