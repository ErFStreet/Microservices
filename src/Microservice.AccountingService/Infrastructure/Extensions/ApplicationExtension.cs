namespace Microservice.AccountingService.Infrastructure.Extensions;

public static class ApplicationExtension
{
    public static void RegisterApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}