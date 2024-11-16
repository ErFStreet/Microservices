namespace Microservice.Infrastructure.Repositories;

public class Repository<TEntity, TKey>(AccountingDbContext dbContext) :
    IRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>, new()
    where TKey : notnull
{
    private readonly DbSet<TEntity> _entity = dbContext.Set<TEntity>();
    public IQueryable<TEntity> Query => _entity.AsQueryable();
    public IQueryable<TEntity> QueryNoTracking => _entity.AsNoTracking();

    public async Task AddAsync(TEntity entity, CancellationToken cancellation)
        => await _entity.AddAsync(entity, cancellation);

    public void Update(TEntity entity)
        => _entity.Update(entity);

    public void Delete(TKey id)
        => _entity.Remove(new TEntity { Id = id });

    public async Task<TEntity?> GetByIdAsync
        (TKey id, CancellationToken cancellation)
        => await _entity.FindAsync(id, cancellation);
}