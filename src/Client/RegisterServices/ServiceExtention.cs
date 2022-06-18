namespace UniversityHostel.Client;

using Account.Shared.Validations;
using Applications.Shared.Validations;
using Applications.Shared.ViewModels;
using ApplicationSettings.Shared.Validations;
using ApplicationSettings.Shared.ViewModels;
using Blazored.LocalStorage;
using Cities.Shared.Validations;
using Cities.Shared.ViewModels;
using CommonLibrary.ViewModels;
using Faculties.Shared.Validations;
using Faculties.Shared.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Payments.Shared.Validations;
using Payments.Shared.ViewModels;
using Residences.Shared.Validations;
using Residences.Shared.ViewModels;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using UniversityHostel.SharedClient;
using UniversityHostel.SharedClient.AuthServices;
using UniversityHostel.SharedClient.HttpServices;

public static class ServiceExtention
{
    public static void ConfigureFluentValidationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserForLoginViewModel>, UserForLoginValidator>();
        services.AddScoped<IValidator<UserForRegisterViewModel>, UserForRegisterValidator>();
        services.AddScoped<IValidator<FacultyViewModel>, FacultyValidator>();
        services.AddScoped<IValidator<ResidenceViewModel>, ResidenceValidator>();
        services.AddScoped<IValidator<ApplicationViewModel>, ApplicationValidator>();
        services.AddScoped<IValidator<PaymentViewModel>, PaymentValidator>();
        services.AddScoped<IValidator<CityViewModel>, CityValidator>();
        services.AddScoped<IValidator<ApplicationSettingViewModel>, ApplicationSettingValidator>();
        services.AddScoped<IValidator<ApplicationStageViewModel>, ApplicationStageValidator>();
    }
    public static void ConfigureAuthentication(this IServiceCollection services, IWebAssemblyHostEnvironment hostEnvironment)
    {

        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(hostEnvironment.BaseAddress) }.EnableIntercept(sp));
        services.AddAuthorizationCore();
        services.AddBlazoredLocalStorage();
        services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
    }
    public static void ConfigureHttpServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IHttpService<>), typeof(HttpService<>));
        services.AddScoped<HttpInterceptorService>();
        services.AddHttpClientInterceptor();
    }
}
