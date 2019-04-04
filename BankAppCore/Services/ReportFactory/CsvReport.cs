using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp.Services
{
    public class CsvReport : Report
    {
        public CsvReport(byte[] data) : base(data)
        {

        }
    }
}