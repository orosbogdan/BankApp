using BankApp.Services;
using BankAppCore.Data.EFContext;
using BankAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static BankAppCore.Data.EFContext.EFContext;

namespace BankApp.Models
{

    public class UserLoggerService
    {
        ShopContext context;

        public UserLoggerService(ShopContext context)
        {
            this.context = context;
        }

        public  void AddLog(string applicationUserId, string actionType, string description)
        {

            UserActionLog log = new UserActionLog();
            log.ActionType = actionType;
            log.Description = description;
            log.ApplicationUser = context.Users.Single(x => x.Id == applicationUserId);

            context.UserActionLogs.Add(log);
            context.SaveChanges();
        }
    }
}