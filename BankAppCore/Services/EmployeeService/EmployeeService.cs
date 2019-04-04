using BankAppCore.Data.Converters;
using BankAppCore.Data.EFContext;
using BankAppCore.Data.Repositories;
using BankAppCore.DataTranferObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using static BankAppCore.Data.EFContext.EFContext;

namespace BankAppCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationUserRepository employeeRepository;
        
        public EmployeeService(ShopContext context,UserManager<ApplicationUser> userManager)
        {
            this.employeeRepository = new ApplicationUserRepository(context,userManager);
        }

        public IEnumerable<EmployeeDTO> getAllEmployees()
        {
            return EmployeeConverter.toDtos(employeeRepository.Get());
        }

        public EmployeeDTO getEmployeeById(string accountId)
        {
            ApplicationUser user = employeeRepository.GetByID(accountId);
            if (user == null) throw new InvalidOperationException("No Employee found with that Id");
            return EmployeeConverter.toDto(user);
        }

        public EmployeeDTO createEmployee(EmployeeDTO employeeDTO)
        {
            ApplicationUser user = employeeRepository.GetByID(employeeDTO.Id);

            if (user == null)
            {
                ApplicationUser newUser = new ApplicationUser()
                {
                    Email = employeeDTO.Username,                 
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = employeeDTO.Username,
                    RegisterDate = DateTime.Now
                };

                return EmployeeConverter.toDto(employeeRepository.GetByID(employeeDTO.Id));
            }
            else
            {
                throw new InvalidOperationException("User already exists");
            }
        }


        public void updateEmployee(PasswordChangeModel passwordChangeModel)
        {
            employeeRepository.Update(passwordChangeModel);
        }


        public void deleteEmployee(string employeeId)
        {
  
        }


    }
}
