using Eschody.Application.Configuration;

namespace Eschody.Application;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Configure.SetUpServicesDependencies(builder);

        var app = builder.Build();
        Configure.SetUpWebApplicationDependencies(app);
        Configure.RunApplication(app);
    }
}