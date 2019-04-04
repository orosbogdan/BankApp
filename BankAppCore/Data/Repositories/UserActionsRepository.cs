using BankAppCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppCore.Data.Repositories
{
    public class UserActionLogRepository  
    {
        private EFContext.EFContext.ShopContext context;
        private bool disposed = false;

        public UserActionLogRepository(EFContext.EFContext.ShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserActionLog> Get()
        {
            return context.UserActionLogs.ToList();
        }

        public UserActionLog GetByID(int id)
        {
            return context.UserActionLogs.Find(id);
        }

        public void Insert(UserActionLog entity)
        {
            context.UserActionLogs.Add(entity);
            context.SaveChanges();
        }

        public void Update(UserActionLog entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            UserActionLog UserActionLog = context.UserActionLogs.Find(id);
            context.UserActionLogs.Remove(UserActionLog);
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
