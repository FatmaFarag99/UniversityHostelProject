namespace CommonLibrary.Server;

public interface IBaseSettingUnitOfWork<TEntity>
    where TEntity : BaseEntity
{
    Task<TEntity> ReadAsync();
    Task<TEntity> UpdateAsync(TEntity entity);
}
