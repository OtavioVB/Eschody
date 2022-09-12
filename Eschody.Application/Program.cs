using Eschody.Application.Configuration;

namespace Eschody;

public class Program
{
    public static void Main(string[] args)
    {
        var configure = new Configure(WebApplication.CreateBuilder(args));
        configure.CreateBuilderServicesDependences();
        configure.CreateWebApplication();
    }
}