using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SkyNotes.Common.DataContext.SqlServer;

public static class SkyNotesContextExtension
{
    public static IServiceCollection AddSkyNotesContext(
        this IServiceCollection services,
        string connectionString = "DEFAULT CONNECTION STRING")
    {
        services.AddDbContext<SkyNotesContext>(options =>
            {
                options.UseSqlServer(connectionString);

                options.LogTo(Console.WriteLine, 
                    new[] { Microsoft.EntityFrameworkCore
                        .Diagnostics.RelationalEventId.CommandExecuting });
            }, 
            
            contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

        return services;
    }
}