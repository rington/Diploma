using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientsService;

        private readonly IMapper _mapper;

        public ClientsController(IClientService service, IMapper mapper)
        {
            _clientsService = service;
            _mapper = mapper;
        }

        [Route("api/clients/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _clientsService.GetClientById(id);

            if (client == null)
            {
                return NotFound();
            }

            var clientView = _mapper.Map<ClientDTO, ClientView>(client);

            return Ok(clientView);
        }

        [Route("api/clients")]
        [HttpGet]
        public async Task<IEnumerable<ClientView>> GetAll()
        {
            var clients = await _clientsService.GetAllClients();

            return _mapper.Map<IEnumerable<ClientDTO>, IEnumerable<ClientView>>(clients);
        }

        [Route("api/clients")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ClientView client)
        {
            var clientDTO = _mapper.Map<ClientView, ClientDTO>(client);

            await _clientsService.AddClient(clientDTO);

            _clientsService.SaveChanges();

            return Ok();
        }

        [Route("api/clients")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ClientView client)
        {
            var clientDTO = _mapper.Map<ClientView, ClientDTO>(client);

            await _clientsService.UpdateClient(clientDTO);

            _clientsService.SaveChanges();

            return Ok();
        }

        [Route("api/clients/{id:int}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_clientsService.DeleteClient(id))
            {
                _clientsService.SaveChanges();

                return Ok();
            }

            return NotFound();
        }

        [Route("api/clients/name/{clientFirstName}/{clientLastName}")]
        [HttpGet]
        public async Task<ClientView> GetClientByName(string clientFirstName, string clientLastName)
        {
            var client = await _clientsService.GetClientByName(clientFirstName, clientLastName);

            return _mapper.Map<ClientDTO, ClientView>(client);
        }
        [Route("api/clients/rating/{rating}")]
        [HttpGet]
        public async Task<IEnumerable<ClientView>> GetClientByRating(int rating)
        {
            var client = await _clientsService.GetClientsByRating(rating);

            return _mapper.Map<IEnumerable<ClientDTO>, IEnumerable<ClientView>>(client);
        }
    }
}
