using Eschody.Domain.Contracts.Infrascructure.Security.Cryptography;
using Eschody.Infrascructure.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Infrascructure.Repositories;
using Eschody.Infrascructure.Data.Maps;
using Eschody.Domain.Models.DTOs;
using Eschody.Domain.Contracts.Infrascructure.Maps;
using Eschody.Infrascructure.Data;
using System.Runtime.CompilerServices;

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
        
        _webApplicationBuilder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlite(connectionString));
        _webApplicationBuilder.Services.AddDatabaseDeveloperPageExceptionFilter();

        _webApplicationBuilder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<DataContext>();

        AddDependences();

        _webApplicationBuilder.Services.AddRazorPages();
    }

    private void AddDependences()
    {
        _webApplicationBuilder.Services.AddTransient<IBaseMap<Assignment>, AssignmentMap>();


        _webApplicationBuilder.Services.AddTransient<IHashEncrypter, HashEncrypter>();
        _webApplicationBuilder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();

        _webApplicationBuilder.Services.AddTransient<IBaseMap<Assignment>, AssignmentMap>();
        _webApplicationBuilder.Services.AddTransient<IBaseMap<Suggestion>, SuggestionMap>();
        _webApplicationBuilder.Services.AddTransient<IBaseMap<News>, NewsMap>();
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
