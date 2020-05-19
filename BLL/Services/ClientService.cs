using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;
        public ClientService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow; 
            _mapper = mapper;
        }

        public async Task<ClientDTO> GetClientById(int clientId)
        {
            var client = await _uow.Clients.Get(clientId);
            return _mapper.Map<Client, ClientDTO>(client);
        }

        public async Task<IEnumerable<ClientDTO>> GetAllClients()
        {
            var clients = await _uow.Clients.GetAll();
            return _mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(clients);
        }
        public async Task AddClient(ClientDTO client)
        {
            await _uow.Clients.Create(_mapper.Map<ClientDTO, Client>(client));
        }
        public async Task UpdateClient(ClientDTO client)
        {
            await _uow.Clients.Update(_mapper.Map<ClientDTO, Client>(client));
        }

        public bool DeleteClient(int clientId)
        {
            return _uow.Clients.Delete(clientId);
        }

        public async Task<ClientDTO> GetClientByName(string clientFirstName, string clientLastname)
        {
            var client = (await _uow.Clients.Find(c => c.FirstName == clientFirstName && c.LastName == clientLastname)).First();
            return _mapper.Map<Client, ClientDTO>(client);
        }

        public async Task<IEnumerable<ClientDTO>> GetClientsByRating(double rating)
        {
            var clients = await _uow.Clients.Find(c => c.Rating == rating);
            return _mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(clients);
        }
        public void SaveChanges()
        {
            _uow.Save();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
