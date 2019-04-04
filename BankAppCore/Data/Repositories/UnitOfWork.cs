using BankAppCore.Data.EFContext;
using Microsoft.AspNet.Identity;
using System;
using static BankAppCore.Data.EFContext.EFContext;
/*
namespace BankAppCore.Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private ShopContext context;
        private UserManager<ApplicationUser> userManager;
        private AccountRepository accountRepository;
        private BillRepository billRepository;
        private ClientRepository clientRepository;
        private UserActionLogRepository userActionLogRepository;
        private ApplicationUserRepository applicationUserRepository;

        public UnitOfWork(ShopContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public AccountRepository AccountRepository
        {
            get
            {

                if (this.accountRepository == null)
                {
                    this.accountRepository = new AccountRepository(context);
                }
                return accountRepository;
            }
        }

        public BillRepository BillRepository
        {
            get
            {

                if (this.billRepository == null)
                {
                    this.billRepository = new BillRepository(context);
                }
                return billRepository;
            }
        }

        public ClientRepository ClientRepository
        {
            get
            {

                if (this.clientRepository == null)
                {
                    this.clientRepository = new ClientRepository(context);
                }
                return clientRepository;
            }
        }
        
        public UserActionLogRepository UserActionLogRepository
        {
            get
            {

                if (this.userActionLogRepository == null)
                {
                    this.userActionLogRepository = new UserActionLogRepository(context);
                }
                return userActionLogRepository;
            }
        }


        public ApplicationUserRepository ApplicationUserRepository
        {
            get
            {

                if (this.applicationUserRepository == null)
                {
                    this.applicationUserRepository = new ApplicationUserRepository(context);
                }
                return applicationUserRepository;
            }


        }
        private bool disposed = false;

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
}*/