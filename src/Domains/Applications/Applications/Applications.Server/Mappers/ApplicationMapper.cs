namespace Faculties.Mappers;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Application, ApplicationViewModel>().ReverseMap();
    }
}
