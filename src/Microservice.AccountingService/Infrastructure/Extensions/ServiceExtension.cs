using Microservice.Application.Common;
using Microservice.Application.Common.Behaviors;
using Microservice.Application.Common.Interfaces;
using Microservice.Infrastructure;
using Microservice.Infrastructure.Repositories;
using System.Reflection;

namespace Microservice.AccountingService.Infrastructure.Extensions;

public static class ServiceExtension
{
    public static void RegisterServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddHealthChecks();
    }

    public static void RegisterDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AccountingDbContext>(options =>
        {
            options.UseSqlServer
            (configuration["DatabaseSettings:ConnectionString"]);
        });
    }

    public static void RegisterDependencyInjection(this
        IServiceCollection services)
    {
        services.AddMediatR(current =>
        {
            current.RegisterServicesFromAssembly(typeof(IAssembly).Assembly);
        });

        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,,>));

        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<>));
    }

    public static void RegisterApiVersioning(this IServiceCollection
        services)
    {
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
        });
    }

    public static void RegisterAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters =
                new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(configuration["JwtSetting:SecretKey"]!))
                };
        });
    }
}