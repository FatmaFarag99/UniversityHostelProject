namespace ApplicationSettings.Mappers;

public class ApplicationStageMapper : Profile
{
    public ApplicationStageMapper()
    {
        CreateMap<ApplicationStage, ApplicationStageViewModel>().ReverseMap();
    }
}
