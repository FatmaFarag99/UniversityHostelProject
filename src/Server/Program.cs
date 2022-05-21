using CommonLibrary.Server.Middlewares;
using CommonLibrary.AssemplyScanning;
using StateLog.AspNetCore;
using CommonLibrary;
using CommonLibrary.Server;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddInstallerFromReferancedAssemblies(builder.Configuration, typeof(Program).Assembly, "*.Server.dll");

WebApplication app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    ApplicationContext context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    if (builder.Configuration.GetValue<bool>("AppSettings:Migrate"))
        context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "University Hostel V1");
});

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