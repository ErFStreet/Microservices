namespace Microservice.Infrastructure;

public class UnitOfWork<TDbContext> : IUnitOfWork
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;

    public UnitOfWork(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellation)
    {
        try
        {
            return await _dbContext.SaveChangesAsync(cancellation);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Dispose()
    {
        try
        {
            _dbContext.Dispose();
        }
        catch (Exception)
        {
            throw;
        }
    }
}