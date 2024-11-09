namespace Microservice.Application.Common.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity
    : BaseEntity<TKey>, new() where TKey : notnull 
{
    Task AddAsync(TEntity entity, CancellationToken cancellation);
    void Delete(TKey id);
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellation);
    void Update(TEntity entity);

    IQueryable<TEntity> Query { get; }
    IQueryable<TEntity> QueryNoTracking { get; }
}
