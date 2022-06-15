namespace CommonLibrary.Server;

public interface IBaseSettingUnitOfWork<TEntity, TViewModel>
    where TEntity : BaseEntity
    where TViewModel : BaseViewModel
{
    Task<TViewModel> ReadAsync();
    Task<TViewModel> UpdateAsync(TViewModel viewModel);
}
