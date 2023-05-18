using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SkyNotes.Common.DataContext.Sqlite {
    public static class SkyNotesContextExtension {
        public static IServiceCollection AddSkyNotesContext(this IServiceCollection services, 
            string relativePath = "..", string databaseFileName = "SkyNotes.db") {
            string databasePath = Path.Combine(relativePath + databaseFileName);

            services.AddDbContext<SkyNotesContext>(options =>
            {
                options.UseSqlite($"Data Source={databasePath}");

                options.LogTo(WriteLine,
                  new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
            },
            
            contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

            return services;
        }
    }
}
