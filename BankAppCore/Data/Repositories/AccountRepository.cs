
using BankAppCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace BankAppCore.Data.Repositories
{
    public class AccountRepository 
    {
        private EFContext.EFContext.ShopContext context;
        private bool disposed = false;

        public AccountRepository(EFContext.EFContext.ShopContext context)
        {
            this.context = context;
        }

        public  IEnumerable<Account> Get()
        {
            return context.Accounts.Include(x=>x.Client).ToList();
        }

        public  Account GetByID(int id)
        {
            return context.Accounts.Include(x => x.Client).First(x => x.Id==id);
        }

        public  void Insert(Account entity)
        {
            context.Accounts.Add(entity);
            context.SaveChanges();
        }

        public  void Update(Account entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Account account = context.Accounts.Find(id);
            context.Accounts.Remove(account);
            context.SaveChanges();

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
