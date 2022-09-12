using Eschody.Application.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Eschody.Infrascructure.Data;

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