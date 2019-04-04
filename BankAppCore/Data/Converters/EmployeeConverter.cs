using BankAppCore.Data.EFContext;
using BankAppCore.DataTranferObjects;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppCore.Data.Converters
{
    public class EmployeeConverter
    {
        public static EmployeeDTO toDto(ApplicationUser employee)
        {
            return new EmployeeDTO
            {
                Id=employee.Id,
                Username=employee.UserName
            };
        }


        public static IEnumerable<EmployeeDTO> toDtos(IEnumerable<ApplicationUser> employees)
        {
            List<EmployeeDTO> result = new List<EmployeeDTO>();

            foreach (ApplicationUser applicationUser in employees)
            {
                result.Add(toDto(applicationUser));
            }
            return result;

        }
    }
}
