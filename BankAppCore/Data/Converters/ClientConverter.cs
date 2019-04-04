using BankAppCore.DataTranferObjects;
using BankAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppCore.Data.Converters
{
    public class ClientConverter
    {
        public static ClientDTO toDto(Client client)
        {
            return new ClientDTO
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                SocialSecurityNumber = client.SocialSecurityNumber,
                IdentityCardNumber = client.IdentityCardNumber
            };
        }

        public static IEnumerable<ClientDTO> toDtos(IEnumerable<Client> clients)
        {
            List<ClientDTO> result = new List<ClientDTO>();

            foreach (Client client in clients)
            {
                result.Add(toDto(client));
            }
            return result;

        }


    }
}
