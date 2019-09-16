using ClientsProject.Models;
using ClientsProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ClientsProject.Controllers
{
    [ApiController]
    [Route(ApiConstants.BaseUri + "/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(IClientService clientsService, ILogger<ClientsController> logger)
        {
            _clientService = clientsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAlls()
        {
            var clients = await _clientService.GetAlls();
            return Ok(clients);
        }

        [HttpGet(ApiConstants.ClientPageUri)]
        public async Task<ActionResult<ClientTuple>> GetByPage(int page)
        {
            var clientsTask = _clientService.GetItemsPerPage(page);
            var countTask = _clientService.Count();

            await Task.WhenAll(clientsTask, countTask);

            return Ok(new ClientTuple
            {
                Items = clientsTask.Result,
                Count = countTask.Result
            });
        }

        [HttpGet(ApiConstants.IdParamUri)]
        public async Task<ActionResult<ClientDto>> Get(int id)
        {
            var client = await _clientService.Get(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ClientDto client)
        {
            await _clientService.Update(client);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ClientDto client)
        {
            var id = await _clientService.Create(client);
            return Created($"/{ApiConstants.BaseUri}/{ApiConstants.IdParamUri}/{id}", id);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogWarning("Se va a borrar un cliente");
            await _clientService.Delete(id);
            return Ok();
        }
    }
}
