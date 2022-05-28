﻿namespace UniversityHostel.Client;

using Account.Shared.Validations;
using Blazored.LocalStorage;
using CommonLibrary.ViewModels;
using Faculties.Shared.Validations;
using Faculties.Shared.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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