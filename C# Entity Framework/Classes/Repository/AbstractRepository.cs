using Microsoft.EntityFrameworkCore;

abstract class AbstractRepository<T> where T : class
{
    protected FanDatabase _dbContext;
    protected DbSet<T> _table;
    public AbstractRepository(FanDatabase context)
    {   
        _dbContext = context;
        _table = _dbContext.Set<T>();
    }
    public abstract string GetGeneralInfo(int id);
    public abstract T GetById(int id);
    public abstract void RemoveById(int id);
    public abstract void SaveChanges();
}