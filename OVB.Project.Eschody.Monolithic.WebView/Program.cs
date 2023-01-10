using Microsoft.EntityFrameworkCore;
using OVB.Project.Eschody.Monolithic.Domain.AccountContext.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Domain.AssignmentContext.DataTransferObject;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Mapping;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Mapping.Interfaces;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Repositories;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Repositories.Base;
using OVB.Project.Eschody.Monolithic.Infrascructure.Data.Repositories.Base.Interfaces;

namespace OVB.Project.Eschody.Monolithic.WebView;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        // Infra - Mappings
        builder.Services.AddSingleton<IMapping<Account>, AccountMapping>();
        builder.Services.AddSingleton<IMapping<Assignment>, AssignmentMapping>();

        builder.Services.AddDbContext<DataContext>(p => p.UseNpgsql(builder.Configuration.GetConnectionString("PostgreeSupaBaseConnection")!.ToString(), p => p.MigrationsAssembly("OVB.Project.Eschody.Monolithic.WebView")));

        // Infra - Repositories
        builder.Services.AddScoped<IBaseRepository<Account>, AccountRepository>();
        builder.Services.AddScoped<BaseRepository<Account>, AccountRepository>();

        builder.Services.AddScoped<IBaseRepository<Assignment>, AssignmentRepository>();
        builder.Services.AddScoped<BaseRepository<Assignment>, AssignmentRepository>();

        var app = builder.Build();
        /*
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();*/
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}