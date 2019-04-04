
using BankApp.Services;
using BankAppCore.Controllers;
using BankAppCore.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using static BankAppCore.Data.EFContext.EFContext;
 
namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [TestCase]
        public void GetAccountTest()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "Bank")
                .Options;

            // Run the test against one instance of the context
            using (var context = new ShopContext(options))
            {
                var service = new AccountService(context);
                int id = service.createAccount(new BankAppCore.DataTranferObjects.AccountDTO
                {
                    Amount = 100,
                    CreationDate = DateTime.Now,
                    Type = 0,
                    Id = 1,
                }).Id;

            
                Assert.IsTrue(context.Accounts.Single(x=>x.Id == id).Amount==100);
           
            }

        }

        [TestCase]
        public void TestTransfer()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "Bank")
                .Options;

            // Run the test against one instance of the context
            using (var context = new ShopContext(options))
            {
                var service = new AccountService(context);
                var transferService = new TransferService(context);
                int id1 = service.createAccount(new BankAppCore.DataTranferObjects.AccountDTO
                {
                    Amount = 100,
                    CreationDate = DateTime.Now,
                    Type = 0,
                    Id = 2,
                }).Id;
                int id2 = service.createAccount(new BankAppCore.DataTranferObjects.AccountDTO
                {
                    Amount = 200,
                    CreationDate = DateTime.Now,
                    Type = 0,
                    Id = 3,
                }).Id;

                transferService.Transfer(new BankApp.DTOs.Transfer { idReceiver = 1, idSender = 2, amount = 50 });

                Assert.IsTrue(context.Accounts.Single(x => x.Id == 1).Amount == 150);

            }

        }

        [TestCase]
        public void TestAmountOnTransfer()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "Bank2")
                .Options;

            // Run the test against one instance of the context
            using (var context = new ShopContext(options))
            {
                var service = new AccountService(context);
                var transferService = new TransferService(context);
                int id1 = service.createAccount(new BankAppCore.DataTranferObjects.AccountDTO
                {
                    Amount = 100,
                    CreationDate = DateTime.Now,
                    Type = 0,
                    Id = 2,
                }).Id;
                int id2 = service.createAccount(new BankAppCore.DataTranferObjects.AccountDTO
                {
                    Amount = 200,
                    CreationDate = DateTime.Now,
                    Type = 0,
                    Id = 3,
                }).Id;

                try { 
                transferService.Transfer(new BankApp.DTOs.Transfer { idReceiver = 1, idSender = 2, amount = -50 });
                    Assert.Fail();
                }
                catch
                {
                    Assert.Pass();
                }
                 

            }

        }

        [TestCase]
        public void TestClientControllerGetById()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "Bank3")
                .Options;

            // Run the test against one instance of the context
            using (var context = new ShopContext(options))
            {
                ClientController clientController = new ClientController(context);

                clientController.CreateClient(new
                    BankAppCore.DataTranferObjects.ClientDTO
                    {
                    SocialSecurityNumber="432234",
                    FirstName="Mihai",
                    LastName="Gavril",
                    Address="Cluj",
                    IdentityCardNumber="CJ43125"

                    }
                    );

                Assert.IsTrue(clientController.GetClientById("432234").IdentityCardNumber == "CJ43125");



            }

        }

        [TestCase]
        public void TryInsertInvalidUser()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "Bank4")
                .Options;

            // Run the test against one instance of the context
            using (var context = new ShopContext(options))
            {
                ClientController clientController = new ClientController(context);

            
                try
                {
                    clientController.CreateClient(new
                   BankAppCore.DataTranferObjects.ClientDTO
                    {
                        SocialSecurityNumber = "432231232132132131231231231234",

                    }
                   );

                    Assert.Fail();
                }
                catch
                {
                    Assert.Pass();
                }
 


            }

        }

        [TestCase]
        public void TestPayBill()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "Bank4")
                .Options;

            // Run the test against one instance of the context
            using (var context = new ShopContext(options))
            {

                var clientService = new ClientService(context);
                var client =
                    new BankAppCore.DataTranferObjects.ClientDTO
                    {
                        IdentityCardNumber = "SM2312312",
                        SocialSecurityNumber = "2413213",
                        Address = "Mehedinti",
                        FirstName = "Oros",
                        LastName = "Bogdan"
                    }
                    ;
                clientService.createClient(client);

                var service = new AccountService(context);
                var accountdto= service.createAccount(new BankAppCore.DataTranferObjects.AccountDTO
                {
                    Amount = 100,
                    CreationDate = DateTime.Now,
                    Type = 0,
                    ClientId = client.SocialSecurityNumber
                });


                



                var transferService = new TransferService(context);


                transferService.PayBill(new BankAppCore.DataTranferObjects.BillDTO
                {
                    ssnClient = "2413213",
                    Amount = 15,
                    Date = DateTime.Now,
                    Provider = "RDS",
                    accountId = accountdto.Id,
                    SecretNumber="24123214",
                    
                    
                });



                Assert.IsTrue(service.getAccountById(accountdto.Id).Amount==85);
            }

        }


    }
}