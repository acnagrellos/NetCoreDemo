using ClientsProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientsProject.Services
{
    public interface IClientService
    {
        Task<int> Create(ClientDto clientDto);
        Task<ClientDto> Get(int id);
        Task<IEnumerable<ClientDto>> GetItemsPerPage(int page);
        Task<int> Count();
        Task<IEnumerable<ClientDto>> GetAlls();
        Task Update(ClientDto clientDto);
        Task Delete(int id);
    }
}
