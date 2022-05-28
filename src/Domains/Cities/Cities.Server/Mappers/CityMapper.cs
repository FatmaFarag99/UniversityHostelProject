namespace Cities.Mappers;

public class CityMapper : Profile
{
    public CityMapper()
    {
        CreateMap<City, CityViewModel>().ReverseMap();
    }
}
