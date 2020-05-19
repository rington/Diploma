using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<IEnumerable<T>> Find(Func<T, bool> predicate);

        Task Create(T item);

        Task Update(T item);

        bool Delete(int id);
    }
}
