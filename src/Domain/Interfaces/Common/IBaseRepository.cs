namespace Domain.Interfaces.Common
{
    public interface IBaseRepository<TEntity> where TEntity : class, IBase
    {
        IQueryable<TEntity> Query();
        Task<TEntity> Get(Guid id);
        Task<TEntity> GetAsNoTraking(Guid id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(Guid id);
    }
}
