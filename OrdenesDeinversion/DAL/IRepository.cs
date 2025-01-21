using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Principal;

namespace OrdenesDeinversion.DAL
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Checks if any IEntity object from the set matches the expression
        /// </summary>
        bool Any(Expression<Func<T, bool>> exp);

        /// <summary>
        /// Asynchronously checks if any IEntity object from the set matches the expression
        /// </summary>
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);

        /// <summary>
        /// Retrieves a single IEntity object from the Database by id.
        /// </summary>
        T? Get(int id);

        /// <summary>
        /// Asynchronously retrieves a single IEntity object from the Database by id.
        /// </summary>
        Task<T?> GetAsync(int id);

        /// <summary>
        /// Returns an IQueriable<IEntity> representing all rows of an IEntity table.
        /// </summary>
        DbSet<T> GetAll();

        /// <summary>
        /// Attachs an IEntity object to the DbContext.
        /// </summary>
        void Create(T entity);

        /// <summary>
        /// Sets an IEntity object as Modified in the DbContext.
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Sets an IEntity object as Removed in the DbContext.
        /// </summary>
        void Delete(T entity);

    }
}
