using BankApp.DTO;
using BankApp.Models;
using BankAppCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BankApp.Services
{
    public class CsvCreator : ReportCreator
    {
        public Report GenerateReport(ReportPeriod reportPeriod)
        {

            return new CsvReport(Encoding.ASCII.GetBytes("sadsad"));

      
        }
    }
}