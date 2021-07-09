using LibroApp.Model.Contexts;
using LibroApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroApp.Model.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBase
    {

        private readonly DbSet<T> _dbSet;
        private readonly LibroAppContext _context;

        public BaseRepository()
        {
            _context = new LibroAppContext();
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            entity.Created = DateTime.Now;
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.Deleted = true;

            _dbSet.Attach(entity);
        }

        public IEnumerable<T> Get()
        {
            return GetQueryable().Where(x => !x.Deleted).ToList();
        }

        public T GetById(int id)
        {
            IEnumerable<T> list = Get();
            return list.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
        }
    }
}
