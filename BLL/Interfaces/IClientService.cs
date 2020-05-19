using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClientService : IDisposable
    {
        Task<ClientDTO> GetClientById(int clientId);
        Task<IEnumerable<ClientDTO>> GetAllClients();
        Task AddClient(ClientDTO client);
        Task UpdateClient(ClientDTO client);
        bool DeleteClient(int clientId);
        Task<ClientDTO> GetClientByName(string clientFirstName, string clientLastName);
        Task<IEnumerable<ClientDTO>> GetClientsByRating(double rating);
        void SaveChanges();

    }
}
