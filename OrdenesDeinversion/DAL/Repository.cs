using Microsoft.EntityFrameworkCore;
using OrdenesDeinversion.Models.Entity;
using System;
using System.Linq.Expressions;

namespace OrdenesDeinversion.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context Context;

        public Repository(Context Context)
        {
            this.Context = Context;
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return this.Context.Set<T>().Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await this.Context.Set<T>().AnyAsync(exp);
        }

        public void Create(T entity)
        {
            this.Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            if (this.Context.Entry(entity).State == EntityState.Detached)
            {
                this.Context.Set<T>().Attach(entity);
            }
            this.Context.Entry(entity).State = EntityState.Deleted;
            this.Context.Set<T>().Remove(entity);
        }

        public T? Get(int id)
        {
            return this.Context.Set<T>().Find(id);
        }

        public DbSet<T> GetAll()
        {
            return this.Context.Set<T>();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
