namespace ApplicationSettings.Mappers;

public class ApplicationSettingMapper : Profile
{
    public ApplicationSettingMapper()
    {
        CreateMap<ApplicationSetting, ApplicationSettingViewModel>().ReverseMap();
    }
}
