using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;
using Model.Trello.Persistence.Context;
using Npgsql;

namespace Model.Trello.Persistence.Repositories
{
    public class UserEntityRepositoryADO : IUserEntityRepositoryADO
    {
        private AdoContext Context;

        public UserEntityRepositoryADO(AdoContext context)
        {
            Context = context;
        }

        public async Task<UserEntity> AddUser(UserEntity entity)
        {

            string commandText = $"INSERT INTO tab_user " +
                                    $@"(""Name"", ""Password"", ""DateCreated"") " +
                                    $"VALUES " +
                                    $"(@Name, @Password, @DateTimeCreated);";

            using var cmd = AdoContext.CreateCommand();

            cmd.CommandText = commandText;

            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Password", entity.Password);
            cmd.Parameters.AddWithValue("@DateTimeCreated", DateTime.UtcNow);

            Context.Connection.Open();
            cmd.Connection = (NpgsqlConnection?)Context.Connect();
            await cmd.ExecuteNonQueryAsync();
            

            return entity;

        }
    }
}
