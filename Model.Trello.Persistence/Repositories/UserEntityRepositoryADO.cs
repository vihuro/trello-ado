using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;
using Npgsql;
using System.Data;

namespace Model.Trello.Persistence.Repositories
{
    public class UserEntityRepositoryADO : IUserEntityRepositoryADO
    {
        private readonly IDbConnection _connection;
        public UserEntityRepositoryADO(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<UserEntity> AddUser(UserEntity entity)
        {

            string commandText = $"INSERT INTO tab_users " +
                                    $@"(""Name"", ""Password"", ""DateCreated"") " +
                                    $"VALUES " +
                                    $"(@Name, @Password, @DateCreated) " +
                                    $@"RETURNING ""Id"", ""DateCreated"";";


            using (var cmd = (NpgsqlCommand)_connection.CreateCommand())
            {
                cmd.CommandText = commandText;

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Password", entity.Password);
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.UtcNow);

                var result = await cmd.ExecuteScalarAsync();

                if(result != DBNull.Value)
                {
                }

                



            }




            return entity;

        }
    }
}
