using BankApp.DTO;
using BankApp.Models;
using BankAppCore.Data.EFContext;
using BankAppCore.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using static BankAppCore.Data.EFContext.EFContext;

namespace BankApp.Services
{
    public class PdfCreator : ReportCreator
    {
        private ShopContext applicationDbContext;

        public PdfCreator(ShopContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Report GenerateReport(ReportPeriod reportPeriod)
        {
                 
            MemoryStream stream = new MemoryStream();

            UserActionLog[] logs = applicationDbContext.UserActionLogs.Where(x => x.Date >= reportPeriod.Start && x.Date <= reportPeriod.End && x.ApplicationUser.Id == reportPeriod.ApplicationUserId).ToArray();

            return new CsvReport(stream.GetBuffer());
        }
    }
}