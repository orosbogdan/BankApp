using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppCore.DataTranferObjects
{
    public class AccountDTO
    {     
        public int Id { get; set; }
        [DefaultValue(0)]
        public short Type { get; set; }
        [DefaultValue(0)]
        public int Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public string ClientId { get; set; }
    }
}
