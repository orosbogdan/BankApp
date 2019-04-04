using BankApp.DTOs;
using BankApp.Models;
using BankAppCore.Data.Repositories;
using BankAppCore.DataTranferObjects;
using BankAppCore.Models;
using System;
using System.Linq;

using static BankAppCore.Data.EFContext.EFContext;

namespace BankApp.Services
{
    public class TransferService
    {
        private  AccountRepository accountRepository;
        private BillRepository billRepository;
        private ClientRepository clientRepositorys;

        public TransferService(ShopContext shopContext)
        {
            this.accountRepository = new AccountRepository(shopContext);
            this.billRepository = new BillRepository(shopContext);
            this.clientRepositorys = new ClientRepository(shopContext);
        }

        public Transfer Transfer(Transfer transfer) {
             
            if (!(accountRepository.Get().Any(x => x.Id == transfer.idSender) && accountRepository.Get().Any(x => x.Id == transfer.idReceiver)))
              throw new ArgumentException("Account ids are invalid");

            Account sender = accountRepository.Get().Single(x => x.Id == transfer.idSender);
            Account receiver = accountRepository.Get().Single(x => x.Id == transfer.idReceiver);
            if(transfer.amount<=0) throw new ArgumentException("the sender does not have enough funds");

            if (!(sender.Amount >= transfer.amount)) throw new ArgumentException("the sender does not have enough funds");


            sender.Amount -= transfer.amount;
            receiver.Amount += transfer.amount;

            accountRepository.Update(sender);
            accountRepository.Update(receiver);

        
            return transfer;
        }

        public void PayBill(BillDTO billdto)
        {
            Client client = clientRepositorys.GetByID(billdto.ssnClient);

            Bill bill = new Bill
            {
                Client = client,
                Date = DateTime.Now,
                Provider = billdto.Provider,
                SecretNumber = billdto.Provider,
                Amount = billdto.Amount
            };


            Account account = accountRepository.GetByID(billdto.accountId);

            account.Amount -= billdto.Amount;

            accountRepository.Update(account);

            billRepository.Insert(bill);
        }


    }
}