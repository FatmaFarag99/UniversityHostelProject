namespace Applications.Server.UnitOfWorks;

public class ApplicationUnitOfWork : BaseUnitOfWork<Application, ApplicationViewModel>, IApplicationUnitOfWork
{
    public ApplicationUnitOfWork(IApplicationRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
