namespace BasicInformations.Mappers;

public class FacultyMapper : Profile
{
    public FacultyMapper()
    {
        CreateMap<BasicInformation, BasicInformationViewModel>().ReverseMap();
    }
}
