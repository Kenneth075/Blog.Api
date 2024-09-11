using Infracstructure.SeedData;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Extensions
{
    public static class StartupDbExtension
    {
        public static void CreateDBIfNotExist(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<BlogDbContext>>();
            var blogContext = services.GetRequiredService<BlogDbContext>();

            try
            {
                var databaseCreated = blogContext.Database.GetService<IDatabaseCreator>()
                    as RelationalDatabaseCreator;

                if (databaseCreated != null)
                {
                    logger.LogInformation("Enter databaseCreated");
                    if (!databaseCreated.CanConnect())
                    {
                        databaseCreated.Create();
                        logger.LogInformation("Enter databaseCreated Create");
                    }

                    if (!databaseCreated.HasTables())
                    {
                        databaseCreated.CreateTables();
                        logger.LogInformation("Enter databaseCreated CreateTable");
                    }

                    DBInitializerSeedData.InitializeDatabase(blogContext);
                    logger.LogInformation("Database created");
                }

            }
            catch (Exception ex)
            {

                logger.LogError($"An error occur {ex.Message}");
            }


        }
    }
}
