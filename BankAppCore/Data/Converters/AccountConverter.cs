using BankAppCore.DataTranferObjects;
using BankAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppCore.Data.Converters
{
    public class AccountConverter
    {
        public static AccountDTO toDto(Account account)
        {
            if(account.Client!=null)
            return new AccountDTO
            {
                Id = account.Id,
                ClientId = account.Client.SocialSecurityNumber,
                Amount = account.Amount,
                CreationDate=account.CreationDate,
                Type=account.Type
            
            };
            else
                return new AccountDTO
                {
                    Id = account.Id,                  
                    Amount = account.Amount,
                    CreationDate = account.CreationDate,
                    Type = account.Type

                };
        }


        public static IEnumerable<AccountDTO> toDtos(IEnumerable<Account> accounts)
        {
            List<AccountDTO> result = new List<AccountDTO>();

            foreach(Account acc in accounts)
            {
                result.Add(toDto(acc));
            }
            return result;

        }


    }
}
