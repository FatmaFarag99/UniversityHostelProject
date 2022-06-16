namespace Applications.Mappers;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Application, ApplicationViewModel>().ReverseMap();

        CreateMap<ApplicationBasicInformation, ApplicationBasicInformationViewModel>().ReverseMap();

        CreateMap<ApplicationDocument, ApplicationDocumentViewModel>().ReverseMap();
    }
}