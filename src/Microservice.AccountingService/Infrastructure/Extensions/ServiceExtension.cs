using FluentValidation.AspNetCore;

namespace Microservice.AccountingService.Infrastructure.Extensions;

public static class ServiceExtension
{
    public static void RegisterServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers()
         .AddFluentValidation(current =>
         {
             current.RegisterValidatorsFromAssembly
             (typeof(IAssembly).Assembly);
         });

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

        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void RegisterApiVersioning(this IServiceCollection
        services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);

            options.ReportApiVersions = true;

            options.AssumeDefaultVersionWhenUnspecified = true;

            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
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