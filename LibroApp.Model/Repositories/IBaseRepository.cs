using LibroApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroApp.Model.Repositories
{
    public interface IBaseRepository<T> where T : class, IBase
    {
        IQueryable<T> GetQueryable();

        IEnumerable<T> Get();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task Save();

    }
}
