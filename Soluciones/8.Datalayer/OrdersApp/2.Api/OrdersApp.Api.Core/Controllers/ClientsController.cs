using Microsoft.AspNetCore.Mvc;
using OrdersApp.Api.Configuration;
using OrdersApp.Domain.Models;
using OrdersApp.Domain.Models.Exceptions;
using OrdersApp.Services.Contracts;
using System.Threading.Tasks;

namespace OrdersApp.Api.Core.Controllers
{
    [Route(ApiConstants.BaseUri + "/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAlls()
        {
            var clients = await _clientsService.GetAlls();
            return Ok(clients);
        }

        [HttpGet(ApiConstants.IdParamUri)]
        public async Task<ActionResult> Get(int id)
        {
            var client = await _clientsService.Get(id);
            return Ok(client);
        }

        [HttpGet("byname")]
        public async Task<ActionResult> GetByName([FromQuery] string name)
        {
            var client = await _clientsService.Get(name);
            return Ok(client);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ClientDto client)
        {
            if (string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.Surname))
            {
                throw new PreConditionFailedModelException();
            }

            await _clientsService.Update(client);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ClientDto client)
        {
            if (string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.Surname))
            {
                throw new PreConditionFailedModelException();
            }

            var id = await _clientsService.Create(client);
            return Created($"/{ApiConstants.BaseUri}/{ApiConstants.IdParamUri}/{id}", id);
        }
    }
}
