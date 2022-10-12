using Eschody.Domain.Contracts.Infrascructure.Repository;
using Eschody.Domain.Contracts.Services.Handlers;
using Eschody.Domain.Contracts.Services.Mail;
using Eschody.Domain.Contracts.Services.Security;
using Eschody.Domain.Contracts.Services.Token;
using Eschody.Infrascructure.Data;
using Eschody.Infrascructure.Repositories.Authentication;
using Eschody.Services.Handlers.Authentication.Create;
using Eschody.Services.Handlers.Authentication.Login;
using Eschody.Services.Security;
using Eschody.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace Eschody.Application.Configuration;

public static class Configure
{
    public static void SetUpServicesDependencies(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddMemoryCache();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo() 
            { 
                Title = "Eschody", 
                Description = "O <strong>Eschody</strong> é uma plaforma open-source criada para alunos que estão em processo de preparação para o vestibular, sendo responsável por ajudá-los a organizar seus estudos, manter-se produtivo, e conhecer seu atual estado perante o processo. Essa é API, utilizada para a comunicação entre o servidor e a page view da plataforma.", 
                Version = "v1",
                Contact = new OpenApiContact()
                {
                    Email = "otaviovb.developer@gmail.com",
                    Name = "Eschody",
                    Url = new Uri("https://github.com/OtavioVB/Eschody")
                }
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }

    public static void SetUpDataContext(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataContext>(options => options.UseSqlite($"Data Source={builder.Environment.ContentRootPath}/eschody.db", b => b.MigrationsAssembly("Eschody.Application")));
    }

    public static void SetUpDependencies(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ITokenService, TokenService>();
        builder.Services.AddSingleton<IHashEncrypter, EncrypterHash>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IHandler<ResponseCreateStudentAccount, RequestCreateStudentAccount>, HandlerCreateStudentAccount>();
        builder.Services.AddTransient<IHandler<ResponseLoginStudentAccount, RequestLoginStudentAccount>, HandlerLoginStudentAccount>();
    }

    public static void SetUpJwtBearer(WebApplicationBuilder builder)
    {
        string jwtKey;

        if (Environment.GetEnvironmentVariable("ESCHODY_JWT_BEARER_KEY") == null)
        {
            throw new Exception("INTERNAL ERROR: JWT Bearer Key not implemented");
        }
        else
        {
            jwtKey = Environment.GetEnvironmentVariable("ESCHODY_JWT_BEARER_KEY")!.ToString();
        }


        builder.Services.AddAuthentication(x =>
        {
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Manager", policy => policy.RequireRole("Manager"));
            options.AddPolicy("Student", policy => policy.RequireRole("Student"));
            options.AddPolicy("Developer", policy => policy.RequireRole("Developer"));
        });
    }

    public static void SetUpWebApplicationDependencies(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }

    public static void RunApplication(WebApplication app)
    {
        app.Run();
    }
}
