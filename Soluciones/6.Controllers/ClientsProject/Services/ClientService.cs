using ClientsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientsProject.Configurations;
using Microsoft.Extensions.Options;

namespace ClientsProject.Services
{
    public class ClientService : IClientService
    {
        private readonly IList<Client> _clients;
        private readonly int _itemPerPage;

        public ClientService(IOptions<AppSettingsModel> options)
        {
            this._clients = new List<Client>()
            {
                new Client(1, "Pepe", "Lopez", 24, "pepe@gmail.com", Gender.Male),
                new Client(2, "Laura", "Sanchez", 24, "laura@gmail.com", Gender.Female),
                new Client(3, "Carlos", "Perez", 24, "carlos@gmail.com", Gender.Male),
                new Client(4, "Rosa", "Garcia", 24, "rosa@gmail.com", Gender.Female)
            };
            _itemPerPage = options.Value.ClientsPerPage;
        }

        public async Task<int> Create(ClientDto clientDto)
        {
            var newId = 1;
            if (_clients.Count() > 0)
            {
                newId = _clients.Max(clientEntity => clientEntity.Id) + 1;
            }

            var client = new Client();
            client.SetId(newId);
            UpdateClient(client, clientDto);
            _clients.Add(client);
            return client.Id;
        }

        public async Task<ClientDto> Get(int id)
        {
            return _clients.FirstOrDefault(client => client.Id == id).ToMapper();
        }

        public async Task<IEnumerable<ClientDto>> GetItemsPerPage(int page)
        {
            return _clients.Skip(_itemPerPage * page)
                           .Take(_itemPerPage)
                           .Select(client => client.ToMapper());
        }

        public async Task<int> Count()
        {
            return this._clients.Count;
        }

        public async Task<IEnumerable<ClientDto>> GetAlls()
        {
            return _clients.Select(client => client.ToMapper());
        }

        public async Task Update(ClientDto clientDto)
        {
            var clientEntity = _clients.FirstOrDefault(c => c.Id == clientDto.Id);
            if (clientEntity != null)
            {
                UpdateClient(clientEntity, clientDto);
            }
            else
            {
                throw new Exception("No se ha encontrado el cliente");
            }
        }

        public async Task Delete(int id)
        {
            var entityToRemove = _clients.FirstOrDefault(client => client.Id == id);
            if (entityToRemove != null)
            {
                _clients.Remove(entityToRemove);
            }
            else
            {
                throw new Exception("No se ha encontrado el cliente");
            }
        }

        private void UpdateClient(Client client, ClientDto clientDto)
        {
            client.Update(
                clientDto.Name,
                clientDto.Surname,
                clientDto.Age,
                clientDto.Email,
                clientDto.Gender);
        }
    }
}
