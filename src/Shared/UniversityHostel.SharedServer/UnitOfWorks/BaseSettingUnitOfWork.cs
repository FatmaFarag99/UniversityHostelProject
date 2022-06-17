namespace CommonLibrary.Server;

public class BaseSettingUnitOfWork<TEntity> : IBaseSettingUnitOfWork<TEntity>
    where TEntity : BaseEntity
{
    private readonly IBaseRepository<TEntity> _repository;
    protected readonly ApplicationContext _context;

    public BaseSettingUnitOfWork(IBaseRepository<TEntity> repository)
    {
        _repository = repository;
        _context = repository.Context;
    }

    public virtual async Task<TEntity> ReadAsync() => (await _repository.GetAllAsync()).FirstOrDefault();

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        TEntity entityFromDb = await _repository.EditAsync(entity);
        await _context.SaveChangesAsync();

        return entityFromDb;
    }
}
