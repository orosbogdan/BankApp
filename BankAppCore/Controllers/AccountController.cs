using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.DTOs;
using BankApp.Models;
using BankApp.Services;
using BankAppCore.DataTranferObjects;
using BankAppCore.Models;
using BankAppCore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BankAppCore.Data.EFContext.EFContext;
using Newtonsoft.Json;

namespace BankAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private AccountService accountService;
        private TransferService transferService;
        private UserLoggerService userActionLog;
        public  bool ShouldLog {get;set;}
        public AccountController(ShopContext shopContext)
        {
              accountService = new AccountService(shopContext);
              transferService = new TransferService(shopContext);
              userActionLog = new UserLoggerService(shopContext);
        }


        [HttpGet]
        [Authorize(Roles ="employee")]
        [Route("get")]
        public IEnumerable<AccountDTO> GetAccounts()
        {
            return accountService.getAllAccounts();
        }


        [HttpGet]
        [Route("getid")]
        [Authorize(Roles = "employee")]
        public AccountDTO GetAccountById(int id)
        {
            return accountService.getAccountById(id);
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "employee")]
        public AccountDTO CreateAccount(AccountDTO accountDTO)
        {
       
            if (ModelState.IsValid)
            {
                AccountDTO  acc = accountService.createAccount(accountDTO);

                if (ShouldLog == true)
                {
                    userActionLog.AddLog(User.Identity.Name, "create account", JsonConvert.SerializeObject(accountDTO));
                }

                return accountDTO;
            }
            else throw new InvalidOperationException("Invalid Input");
        }


        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "employee")]
        public void DeleteAccount(int id)
        {
            accountService.deleteAccount(id);
         
        }


        [HttpPut]
        [Route("update")]
        [Authorize(Roles = "employee")]
        public void UpdateAccount(AccountDTO accountDTO)
        {
            if (ModelState.IsValid)
            {
                accountService.updateAccount(accountDTO.Id,accountDTO);
            }
            else throw new InvalidOperationException("Invalid Input");
        }


        [HttpPost]
        [Route("transfer")]
        [Authorize(Roles = "employee")]
        public Transfer Transfer(Transfer transfer)
        {
            transferService.Transfer(transfer);

            return transfer;
        }


        [HttpPost]
        [Route("paybill")]
        [Authorize(Roles = "employee")]
        public void PayBill(BillDTO billdto)
        {
            transferService.PayBill(billdto);

        }

    }
}