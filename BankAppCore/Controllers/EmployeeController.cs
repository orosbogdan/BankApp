using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAppCore.Data.EFContext;
using BankAppCore.DataTranferObjects;
using BankAppCore.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static BankAppCore.Data.EFContext.EFContext;

namespace BankAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private EmployeeService employeeService;


        public EmployeeController(ShopContext shopContext, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
            employeeService = new EmployeeService(shopContext,userManager);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("get")]
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            return employeeService.getAllEmployees();
        }


        [HttpGet]
        [Route("getid")]
        [Authorize(Roles = "employee")]
        public EmployeeDTO GetEmployeeById(string id)
        {
            return employeeService.getEmployeeById(id);
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "employee")]
        public EmployeeDTO CreateEmployee(EmployeeDTO clientDTO)
        {
            employeeService.createEmployee(clientDTO);
            return clientDTO;
        }


        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "employee")]
        public void DeleteEmployee(string id)
        {
            employeeService.deleteEmployee(id);

        }


        [HttpPut]
        [Route("update")]
        [Authorize(Roles = "employee")]
        public void UpdateEmployee(PasswordChangeModel passwordChangeModel)
        {
            
            employeeService.updateEmployee(passwordChangeModel);

        }

    }
}