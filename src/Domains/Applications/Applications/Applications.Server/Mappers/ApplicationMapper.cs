namespace Applications.Mappers;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Application, ApplicationViewModel>().ReverseMap();

        CreateMap<BasicInformation, BasicInformationViewModel>().ReverseMap();

        CreateMap<ApplicationDocument, ApplicationDocumentViewModel>().ReverseMap();
        CreateMap<ApplicationDocuments, ApplicationDocumentsViewModel>().ReverseMap();
    }
}