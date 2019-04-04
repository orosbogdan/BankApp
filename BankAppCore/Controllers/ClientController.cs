using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankAppCore.DataTranferObjects;
using BankAppCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BankAppCore.Data.EFContext.EFContext;

namespace BankAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private ClientService clientService;


        public ClientController(ShopContext shopContext)
        {
            clientService = new ClientService(shopContext);
        }


        [HttpGet]
        [Authorize(Roles = "employee")]
        [Route("get")]
        public IEnumerable<ClientDTO> GetClients()
        {
            return clientService.getAllClients();
        }


        [HttpGet]
        [Route("getid")]
        [Authorize(Roles = "employee")]
        public ClientDTO GetClientById(string id)
        {
            return clientService.getClientById(id);
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "employee")]
        public ClientDTO CreateClient(ClientDTO clientDTO)
        {
         

         

                clientService.createClient(clientDTO);
                return clientDTO;
 
        }


        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "employee")]
        public void DeleteClient(string id)
        {
            clientService.deleteClient(id);

        }


        [HttpPut]
        [Route("update")]
        [Authorize(Roles = "employee")]
        public void UpdateClient(ClientDTO clientDTO)
        {
           
             clientService.changeClient(clientDTO.SocialSecurityNumber, clientDTO);
     
        }


        [HttpPost]
        [Route("add_account")]
        [Authorize(Roles = "employee")]
        public void LinkAccount(string ssn, int accountid)
        {
            clientService.addAccountToClient(ssn, accountid);
        }


        [HttpPost]
        [Route("remove_account")]
        [Authorize(Roles = "employee")]
        public void UnlinkAccount(string ssn, int accountid)
        {
            clientService.deleteAccountFromClient(ssn, accountid);
        }
    }
}