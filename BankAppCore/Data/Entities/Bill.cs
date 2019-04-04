using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankAppCore.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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


        [Required]
        public virtual Client Client { get; set; }


        public Bill()
        {
            Date = DateTime.Now;
        }
    }
}