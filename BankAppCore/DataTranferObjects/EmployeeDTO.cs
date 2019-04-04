using BankAppCore.Data.EFContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppCore.DataTranferObjects
{
    public class EmployeeDTO
    {
    
        public string Id { get; set; }
        [Required]
        public string Username { get; set; }
        
    }
}
