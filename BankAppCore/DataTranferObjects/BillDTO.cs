using BankAppCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppCore.DataTranferObjects
{
    public class BillDTO
    {

       
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Provider { get; set; }
        [MaxLength(20)]
        [Required]
        public string SecretNumber { get; set; }
        [Required]
        public int Amount { get; set; }

        public DateTime Date { get; set; }
    
        public  string ssnClient { get; set; }
        public int accountId { get; set; }

    }
}
