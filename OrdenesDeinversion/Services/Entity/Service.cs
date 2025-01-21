
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrdenesDeinversion.DAL;
using System;


using OrdenesDeinversion.Models.Entity;
using OrdenesDeinversion.Models.Entity.Dominio;

namespace OrdenesDeinversion.Services.Entity
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {

        private readonly IRepository<TEntity> repository;
        protected readonly IUnitOfWork unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = unitOfWork.GetRepository<TEntity>();
        }

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            try
            {
                repository.Create(entity);
                return await unitOfWork.SaveChangesAsync<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la entidad");
            }
        }

        public virtual async Task<int> CreateAsync(List<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                repository.Create(entity);
            }

            try
            {
                return await unitOfWork.SaveChangesAsync<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear las entidades");
            }
        }


        public virtual async Task<int> DeleteAsync(int id)
        {
            try
            {
                TEntity? entity = await this.GetAsync(id);
                return await this.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar las entidades");
            }
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            try
            {
                repository.Delete(entity);
                return await unitOfWork.SaveChangesAsync<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar la entidad");
            }
        }


        public Task<int> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            try
            {
                DbSet<TEntity> entities = repository.GetAll();
                return entities;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener todas las entidades");
            }
        }

        public virtual async Task<TEntity?> GetAsync(int id)
        {
            TEntity? entity;
            try
            {
                entity = await repository.GetAsync(id);
                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Error al recuperar la entidad");
            }
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            try
            {
                repository.Update(entity);
                return await unitOfWork.SaveChangesAsync<TEntity>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<int> UpdateAsync(List<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                repository.Update(entity);
            }

            try
            {
                return await unitOfWork.SaveChangesAsync<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar las entidades");
            }
        }

    }
}
