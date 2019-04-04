using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAppCore.Models
{
    public partial class Client
    {
        [MaxLength(13)]
        [Key]
        public string SocialSecurityNumber { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string IdentityCardNumber { get; set; }

        public ICollection<Account> Accounts { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}