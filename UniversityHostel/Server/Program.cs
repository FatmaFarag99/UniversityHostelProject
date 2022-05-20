using CommonLibrary.Server.Middlewares;
using CommonLibrary.AssemplyScanning;
using StateLog.AspNetCore;
using CommonLibrary;
using CommonLibrary.Server;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddInstallerFromReferancedAssemblies(builder.Configuration, typeof(Program).Assembly, "*.Server.dll");

builder.Services.AddControllers(config =>
{
    config.Filters.Add(new TrackPerformanceFilter("UniversityHostel", "API"));
    config.Filters.Add(new TrackUsageAttribute("UniversityHostel", "API"));
}).AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(action =>
{
    action.SwaggerDoc("UniversityHostel", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "1.0v",
        Title = "UniversityHostel"
    });
});
WebApplication app = builder.Build();

ApplicationContext context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>();
if(builder.Configuration.GetValue<bool>("AppSettings:Migrate"))
    context.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseApiExceptionHandler(options =>
{
    options.Product = "UniversityHostel";
    options.Layer = "API";
});

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseCors("_myAllowSpecificOrigins");
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();