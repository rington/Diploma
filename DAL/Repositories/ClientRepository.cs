using DAL.DBContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly HotelContext _db;

        public ClientRepository(HotelContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return _db.Clients;
        }

        public async Task<Client> Get(int id)
        {
            return await Task.FromResult(_db.Clients.Find(id));
        }

        public async Task<IEnumerable<Client>> Find(Func<Client, bool> predicate)
        {
            return _db.Clients.Where(predicate).ToList();
        }

        public async Task Create(Client client)
        {
            _db.Clients.Add(client);
        }

        public async Task Update(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
        }
        public bool Delete(int id)
        {
            var client = _db.Clients.Find(id);
            if (client != null)
            {
                _db.Clients.Remove(client);
                return true;
            }

            return false;
        }
    }
}
