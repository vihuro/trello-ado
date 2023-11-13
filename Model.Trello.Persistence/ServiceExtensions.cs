using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.Trello.Domain.Interface;
using Model.Trello.Persistence.Context;
using Model.Trello.Persistence.Migrations;
using Model.Trello.Persistence.Repositories;
using Npgsql;
using System.Data;
using System.Reflection;

namespace Model.Trello.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenteApp(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("trello");

            var database = configuration.GetConnectionString("database");

            var justConnection = configuration.GetConnectionString("justConnection");

            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

            services.AddScoped<IUserEntityRepositoryADO, UserEntityRepositoryADO>();

            services.AddScoped<IUnitOfWorkADO, UnitOfWorkAdo>();

            services.AddScoped<IDbConnection>(con => new NpgsqlConnection(connectionString));

            services.AddScoped<IAdoContext, AdoContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserEntityRepository, UserEntityRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskListEntity, TaskListRepository>();

            var unitOfWorkAdo = services.BuildServiceProvider().GetRequiredService<IUnitOfWorkADO>();

            UpdateDatabase(database, justConnection);

            services.AddFluentMigratorCore()
                    .ConfigureRunner(x =>
                        x.AddPostgres()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(Assembly.Load("Model.Trello.Persistence")).For.All());

            var runner = services.BuildServiceProvider().GetRequiredService<IMigrationRunner>();

            runner.ListMigrations();
            runner.MigrateUp();
        }

        public static void UpdateDatabase(string database, string connection)
        {
            CreateDataBase.CreateTable(database, connection);
        }
    }
}
