using BankAppCore.Data.Converters;
using BankAppCore.Data.Repositories;
using BankAppCore.DataTranferObjects;
using BankAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BankAppCore.Data.EFContext.EFContext;

namespace BankAppCore.Services
{
    public class AccountService : IAccountService 
    {
        private AccountRepository accountRepository;


        public AccountService(ShopContext context)
        {
            accountRepository = new AccountRepository(context);
        }


        public IEnumerable <AccountDTO> getAllAccounts()
        {

            return AccountConverter.toDtos(accountRepository.Get());
        }

        public AccountDTO getAccountById(int accountId) 
        {
            Account account = accountRepository.GetByID(accountId);
            if (account == null) throw new InvalidOperationException("No account found with that accountId");
            return AccountConverter.toDto(account);
        }

        public AccountDTO createAccount(AccountDTO accountDto)  
        {
             if (accountDto.Amount < 0) {
                throw new InvalidOperationException("Impossible to have a negative balance");
                }
                Account account = new Account
                {
                    Client=null,
                    CreationDate=DateTime.Now,
                    Amount=accountDto.Amount,
                    Id=accountDto.Id,
                    Type=accountDto.Type
                };
                 accountRepository.Insert(account);

            return AccountConverter.toDto(account);
        }


    

        public AccountDTO updateAccount(int accountId, AccountDTO accountDto) 
        {
                Account account = accountRepository.GetByID(accountId);

                if (account == null) {
                throw new InvalidOperationException("No account found with that id");
                }

                account.Amount = accountDto.Amount;

                accountRepository.Update(account);
                return AccountConverter.toDto(account);
        }


        public void deleteAccount(int accountId) 
        {
            Account account = accountRepository.GetByID(accountId);
                if (account == null) {
                throw new InvalidOperationException("No account with that accountId");
            }
            accountRepository.Delete(account.Id);
        }

    }
}
