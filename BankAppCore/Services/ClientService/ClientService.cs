using BankAppCore.Data.Converters;
using BankAppCore.Data.Repositories;
using BankAppCore.DataTranferObjects;
using BankAppCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static BankAppCore.Data.EFContext.EFContext;

namespace BankAppCore.Services
{
    public class ClientService : IClientService
    {
      
        private ClientRepository clientRepository;
        private AccountRepository accountRepository;



        public ClientService(ShopContext context)
        {
            accountRepository = new AccountRepository(context);
            clientRepository = new ClientRepository(context);
        }

        public IEnumerable<ClientDTO> getAllClients()
            {
                return ClientConverter.toDtos(clientRepository.Get());
            }

            public ClientDTO getClientById(String clientId) 
            {
                Client client = clientRepository.GetByID(clientId);
                if (client == null) throw new InvalidOperationException("No client found with that clientId");
                return ClientConverter.toDto(client);

            }

            public void createClient(ClientDTO clientDto)  
            {
            var context = new ValidationContext(clientDto, serviceProvider: null, items: null);
          
            var isValid = Validator.TryValidateObject(clientDto, context, null);

            if (!isValid) throw new InvalidOperationException("Invalid client");

            Client client = new Client
                {
                    SocialSecurityNumber = clientDto.SocialSecurityNumber,
                    Address = clientDto.Address,
                    FirstName = clientDto.FirstName,
                    LastName = clientDto.LastName,
                    IdentityCardNumber = clientDto.IdentityCardNumber
                };

                Client possibleAlreadyExistingClient = clientRepository.GetByID(clientDto.SocialSecurityNumber);


                if (possibleAlreadyExistingClient == null) {
                    clientRepository.Insert(client);
               
                } else {
                    throw new InvalidOperationException("Client already exists!");
                }
            }

            public void changeClient(String clientId, ClientDTO clientDto)  
            {
                 Client client = clientRepository.GetByID(clientId);

                if (client == null)
                {
                   throw new InvalidOperationException("No client found with that clientId");
                }

                client.FirstName = clientDto.FirstName;
                client.LastName = clientDto.LastName;
                client.Address = clientDto.Address;
                client.IdentityCardNumber = clientDto.IdentityCardNumber;

                clientRepository.Update(client);
            }

            public void deleteClient(String clientId) 
            {
                Client client = clientRepository.GetByID(clientId);
                if (client == null) {
                    throw new InvalidOperationException("No client with that clientId");
                }
              
                foreach (Account account in client.Accounts) {
                    accountRepository.Delete(account.Id);
                }
                clientRepository.Delete(client.IdentityCardNumber);
            }

            public IEnumerable<AccountDTO> addAccountToClient(String clientId, int accountId)
            {
                Client client = clientRepository.GetByID(clientId);
                Account account = accountRepository.GetByID(accountId);

                if (client == null || account == null) throw new InvalidOperationException("Client or account does not exist");

                account.Client = client;
                accountRepository.Update(account);

                return AccountConverter.toDtos(accountRepository.Get().Where(x => x.Client.SocialSecurityNumber == clientId));

            }


            public IEnumerable<AccountDTO> deleteAccountFromClient(String clientId, int accountId)
            {
                Client client = clientRepository.GetByID(clientId);
                accountRepository.Delete(accountId);


                return AccountConverter.toDtos(accountRepository.Get().Where(x => x.Client.SocialSecurityNumber == clientId));
              
               
            }
}}