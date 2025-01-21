using System.Security.Principal;

namespace OrdenesDeinversion.Services.Entity
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<int> Exists(int id);

        IQueryable<TEntity> GetAll();

        Task<TEntity?> GetAsync(int id);

        Task<int> CreateAsync(TEntity entity);

        Task<int> CreateAsync(List<TEntity> entities);

        Task<int> UpdateAsync(TEntity entity);

        Task<int> UpdateAsync(List<TEntity> entities);

        Task<int> DeleteAsync(int id);

        Task<int> DeleteAsync(TEntity entity);

    }
}
