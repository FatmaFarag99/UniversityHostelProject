namespace BasicInformations.Server;

public class BasicInformationUnitOfWork : BaseUnitOfWork<BasicInformation, BasicInformationViewModel>, IBasicInformationUnitOfWork
{
    public BasicInformationUnitOfWork(IBasicInformationRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
