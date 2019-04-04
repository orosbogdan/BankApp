using BankAppCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace BankAppCore.Data.Repositories
{
    public class ClientRepository
    {
             
            private EFContext.EFContext.ShopContext context;
            private bool disposed = false;

            public ClientRepository(EFContext.EFContext.ShopContext context)
            {
                this.context = context;
            }

            public IEnumerable<Client> Get()
            {
                return context.Clients.ToList();
            }

            public Client GetByID(string id)
            {
                return context.Clients.Find(id);
            }

            public void Insert(Client entity)
            {
                context.Clients.Add(entity);
                context.SaveChanges();
            }

            public void Update(Client entity)
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }

            public void Delete(string id)
            {
                Client client = context.Clients.Find(id);
                context.Clients.Remove(client);
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
