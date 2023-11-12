using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Model.Trello.Persistence.Context;

namespace Model.Trello.Api
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment
                                    .GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                                    ?? "Development";

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{environmentName}.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(config.GetConnectionString("trello"),
                                                        b => b.MigrationsAssembly("Model.Trello.Api"));

            return new AppDbContext(builder.Options);
        }
    }
}
