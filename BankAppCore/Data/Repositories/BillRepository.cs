using BankAppCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace BankAppCore.Data.Repositories
{
    public class BillRepository 
    {
        private EFContext.EFContext.ShopContext context;
        private bool disposed = false;

        public BillRepository(EFContext.EFContext.ShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Bill> Get()
        {
            return context.Bills.ToList();
        }

        public Bill GetByID(int id)
        {
            return context.Bills.Find(id);
        }

        public void Insert(Bill entity)
        {
            context.Bills.Add(entity);
            context.SaveChanges();
        }

        public void Update(Bill entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Bill Bill = context.Bills.Find(id);
            context.Bills.Remove(Bill);
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
