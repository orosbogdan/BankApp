using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp.Services
{
    public class PdfReport : Report
    {
        public PdfReport(byte[] data) : base(data)
        {
        }
    }
}