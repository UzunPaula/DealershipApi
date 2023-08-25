using DealershipManagerApi.Models;
using DealershipManagerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipManagerApi.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        //Add Client: POST /cars
        [HttpPost]
        [Route("clients")]
        public IActionResult Add(Client client)
        {
            _clientService.Add(client);

            return Ok();
        }

        //Get all clients: GET /clients
        [HttpGet]
        [Route("clients")]
        public IActionResult GetAll()
        {
            var result = _clientService.GetAll();

            return Ok(result);
        }

        //Get client by id: GET /clients/{id}
        [HttpGet]
        [Route("clients/{clientId}")]
        public IActionResult GetById(Guid clientId)
        {
            var result = _clientService.Get(clientId);

            return Ok(result);
        }

        //Update client: PUT /clients/{id}
        [HttpPut]
        [Route("clients/{clientId}")]
        public IActionResult Update(Guid clientId, Client client)
        {
            _clientService.Update(clientId, client);

            return Ok();
        }

        //Delete client: DELETE /clients/{id}
        [HttpDelete]
        [Route("clients/{clientId}")]
        public IActionResult Delete(Guid clientId)
        {
            _clientService.Delete(clientId);

            return NoContent();
        }
    }
}
