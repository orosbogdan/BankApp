using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankApp.DTOs
{
    public class Transfer
    {
        [Required]
        public int idSender { get; set; }
        [Required]
        public int idReceiver { get; set; }
        [Required]
        [RegularExpression(@"^[+]?\d+([.]\d+)?$")]
        public int amount { get; set; }
    }
}