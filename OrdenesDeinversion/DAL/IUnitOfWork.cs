using System.Security.Principal;
using System;
using OrdenesDeinversion.Models.Entity;

namespace OrdenesDeinversion.DAL
{
    public interface IUnitOfWork
    {

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

   
        Context GetDbContext<TEntity>() where TEntity : class;

 
        Context GetModelDbContext();


        int SaveChanges<TEntity>() where TEntity : class;


        Task<int> SaveChangesAsync<TEntity>() where TEntity : class;
        bool IsDisposed();
    }
}
