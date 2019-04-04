using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public abstract class Report
    {
        public byte[] Data { get; private set; }
        public Report(byte[]data)
        {
            Data = data;
        }
     
    }
}
