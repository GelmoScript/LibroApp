using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibroApp.Model.Entities;
using LibroApp.Model.Repositories;

namespace LibroApp.Repository.Services
{
    public interface IBaseService<T> : ISelectionable
    {
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(int id, T entity);
        Task<T> Delete(int id);
        IEnumerable<T> Get();
        IEnumerable<T> GetAsParallel();
        int Select();
    }
    public abstract class BaseService<T> : Selectionable, IBaseService<T> where T : class, IBase
    {
        private readonly IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> Delete(int id)
        {
            T entity = _repository.GetById(id);

            if (entity is null)
                return null;

            _repository.Delete(entity);
            await _repository.Save();

            return entity;
        }

        public IEnumerable<T> Get()
        {
            var list = _repository.Get();
            return list;
        }

        public IEnumerable<T> GetAsParallel()
        {
            var list = _repository.Get().AsParallel().ToList();
            return list;
        }

        public Task<T> GetById(int id)
        {
            T entity = _repository.GetById(id);

            if (entity is null)
                return null;

            return Task.FromResult(entity);
        }

        public async Task<T> Add(T entity)
        {
            _repository.Add(entity);
            await _repository.Save();

            return entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            if (id != entity.Id) return null;
            T currentEntity = _repository.GetById(id);

            if (currentEntity is null)
                return null;

            currentEntity = entity;
            currentEntity.Deleted = false;
            _repository.Update(currentEntity);

            await _repository.Save();

            return entity;
        }

        public abstract int Select();
	}
}
