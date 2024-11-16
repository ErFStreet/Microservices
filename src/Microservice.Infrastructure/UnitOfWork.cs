namespace Microservice.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AccountingDbContext _dbContext;

    public UnitOfWork(AccountingDbContext dbContext)
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