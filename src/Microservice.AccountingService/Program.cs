namespace Microservice.AccountingService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.RegisterServices(builder.Configuration);

        builder.Services.RegisterDatabase(builder.Configuration);

        builder.Services.RegisterApiVersioning();

        builder.Services.RegisterDependencyInjection();

        var app = builder.Build();

        app.RegisterApplication();

        app.Run();
    }
}