namespace CommonLibrary.Server;

public class BaseSettingUnitOfWork<TEntity, TViewModel> : IBaseSettingUnitOfWork<TEntity, TViewModel>
    where TEntity : BaseEntity
    where TViewModel : BaseViewModel
{
    private readonly IBaseRepository<TEntity> _repository;
    private readonly IMapper _mapper;
    protected readonly ApplicationContext _context;

    public BaseSettingUnitOfWork(IBaseRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _context = repository.Context;
    }

    public virtual async Task<TViewModel> ReadAsync()
    {
        TEntity entity = (await _repository.GetAllAsync()).FirstOrDefault();
        return _mapper.Map<TViewModel>(entity);
    }

    public virtual async Task<TViewModel> UpdateAsync(TViewModel viewModel)
    {
        TEntity entity = _mapper.Map<TEntity>(viewModel);
        TEntity entityFromDb = await _repository.EditAsync(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TViewModel>(entityFromDb);
    }
}