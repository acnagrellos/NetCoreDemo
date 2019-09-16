using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsProject.Models
{
    public static class ClientsExtensions
    {
        public static ClientDto ToMapper(this Client client)
        {
            return new ClientDto
            {
                Id = client.Id,
                Age = client.Age,
                Email = client.Email,
                Name = client.Name,
                Surname = client.Surname,
                Gender = client.Gender
            };
        }
    }
}
