using Eschody.Application.Configuration;
using Eschody.Infrascructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eschody.Application;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Configure.SetUpDataContext(builder);
        Configure.SetUpServicesDependencies(builder);
        Configure.SetUpDependencies(builder);
        var app = builder.Build();
        Configure.SetUpWebApplicationDependencies(app);
        Configure.RunApplication(app);
    }
}