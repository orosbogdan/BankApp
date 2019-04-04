using System;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BankAppCore.Models
{
    public partial class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DefaultValue(0)]
        public short Type { get; set; }
        [DefaultValue(0)]
        public int Amount { get; set; }    
        public DateTime CreationDate { get; set; }
    
        public virtual Client Client { get; set;}

        public Account()
        {
            CreationDate = DateTime.Now;
        }
    }
}