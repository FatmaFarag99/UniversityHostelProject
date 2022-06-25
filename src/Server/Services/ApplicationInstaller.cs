namespace UniversityHostel.Server.Services;

using CommonLibrary.AssemplyScanning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoMapper;
using StateLog.AspNetCore;
using UniversityHostel.Shared.Services;

public class ApplicationInstaller : IInstaller
{
    private const string _myAllowSpecificOrigins = "_myAllowSpecificOrigins";

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IEmailService, EmailService>();

        services.AddControllers(config =>
        {
            config.Filters.Add(new TrackPerformanceFilter("UniversityHostel", "API"));
            config.Filters.Add(new TrackUsageAttribute("UniversityHostel", "API"));
        }).AddNewtonsoftJson();

        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddCors(options =>
        {
            options.AddPolicy(_myAllowSpecificOrigins, builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "UniversityHostel", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });
    }
}