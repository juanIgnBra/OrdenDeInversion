using OrdenesDeinversion.Models.Entity;
using System;
using OrdenesDeinversion.Models.Entity;


namespace OrdenesDeinversion.DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly Context modelDbContext;
        public UnitOfWork(Context modelDbContext)
        {
            this.modelDbContext = modelDbContext;
        }

        public Context GetDbContext<TEntity>() where TEntity : class
        {
            return GetModelDbContext();
        }

        public Context GetModelDbContext()
        {
            return modelDbContext;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            IRepository<TEntity> repository;

            repository = new Repository<TEntity>(this.GetDbContext<TEntity>());

            return repository as IRepository<TEntity>;
        }

        public bool IsDisposed()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges<TEntity>() where TEntity : class
        {
            return this.GetDbContext<TEntity>().SaveChanges();
        }

        public async Task<int> SaveChangesAsync<TEntity>() where TEntity : class
        {
            return await this.GetDbContext<TEntity>().SaveChangesAsync();
        }
    }
}
