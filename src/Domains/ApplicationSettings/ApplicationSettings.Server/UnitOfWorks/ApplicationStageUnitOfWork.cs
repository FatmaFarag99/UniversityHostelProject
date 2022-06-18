namespace ApplicationSettings.Server.UnitOfWorks;

public class ApplicationStageUnitOfWork : BaseUnitOfWork<ApplicationStage, ApplicationStageViewModel>, IApplicationStageUnitOfWork
{
    private readonly IApplicationStageRepository _repository;

    public ApplicationStageUnitOfWork(IApplicationStageRepository repository, IMapper mapper) : base(repository, mapper)
    {
        this._repository = repository;
    }

    public async Task<ApplicationStageViewModel> ReadLastStage()
    {
        ApplicationStage applicationStage = (await _repository.GetAllAsync()).LastOrDefault();

        return _mapper.Map<ApplicationStageViewModel>(applicationStage);
    }
}
