namespace BasicInformations.Server;

public class BasicInformationRepository : BaseRepository<BasicInformation>, IBasicInformationRepository
{
    public BasicInformationRepository(ApplicationContext context) : base(context)
    {
    }
}
