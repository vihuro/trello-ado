using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.Trello.Domain.Interface;
using Model.Trello.Persistence.Context;
using Model.Trello.Persistence.Context.Command.User;
using Model.Trello.Persistence.Repositories;
using Npgsql;
using System.Data;

namespace Model.Trello.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenteApp(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("trello");
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

            services.AddScoped(provider =>
            {
                return new AdoContext(connectionString);
            });

            //services.AddTransient<IDbConnection>(con => new NpgsqlConnection(connectionString));

            services.AddScoped<IUserEntityRepositoryADO, UserEntityRepositoryADO>();

           // services.AddScoped<IConnectionPsqlRepository, ConnectionPsqlRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserEntityRepository, UserEntityRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskListEntity, TaskListRepository>();
        }
    }
}
