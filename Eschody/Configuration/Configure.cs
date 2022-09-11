using Eschody.Application.Data;
using Eschody.Domain.Contracts.Infrascructure.Security.Cryptography;
using Eschody.Infrascructure.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Eschody.Application.Configuration;

public class Configure
{
    private readonly WebApplicationBuilder _webApplicationBuilder;

    public Configure(WebApplicationBuilder webApplicationBuilder)
    {
        _webApplicationBuilder = webApplicationBuilder;
    }

    public void CreateBuilderServicesDependences()
    {
        var connectionString = _webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        
        _webApplicationBuilder.Services.AddDbContext<EschodyApplicationContext>(options =>
            options.UseSqlite(connectionString));
        _webApplicationBuilder.Services.AddDatabaseDeveloperPageExceptionFilter();

        _webApplicationBuilder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<EschodyApplicationContext>();

        AddDependences();

        _webApplicationBuilder.Services.AddRazorPages();
    }

    private void AddDependences()
    {
        
    }

    public void CreateWebApplication()
    {
        var app = _webApplicationBuilder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area}/{controller}/{action}/{id?}"
            );
        });

        app.MapRazorPages();
        app.Run();
    }
}
