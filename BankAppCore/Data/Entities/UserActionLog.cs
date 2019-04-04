using BankAppCore.Data.EFContext;
using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BankAppCore.Models
{
    public partial class UserActionLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string ActionType { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        
        public DateTime Date { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }


        public UserActionLog()
        {
            Date = DateTime.Now;
        }


    }
}