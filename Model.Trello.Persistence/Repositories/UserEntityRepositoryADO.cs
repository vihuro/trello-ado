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
                    entity.Id = (int)result;
                }

            }

            return entity;

        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            string commandText = @"SELECT ""Id"", ""Name"" ,""DateCreated"" 
                                    from tab_users ORDER BY ""Id"" ASC;";

            using var cmd = (NpgsqlCommand)_connection.CreateCommand();
            cmd.CommandText = commandText;

            var reader = await cmd.ExecuteReaderAsync();

            var lists = new List<UserEntity>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lists.Add(new UserEntity()
                    {
                        DateCreated = (DateTime)reader["DateCreated"],
                        Name = reader["Name"].ToString(),
                        Id = (int)reader["Id"],
                    });
                }
            }

            return lists;
        }
        public async Task<UserEntity> GetUserByName(string name)
        {
            string commandText = @"SELECT * FROM tab_users WHERE ""Name"" = @Name;";

            using var cmd = (NpgsqlCommand)_connection.CreateCommand();

            cmd.CommandText = commandText;

            var userEntity = new UserEntity();

            cmd.Parameters.AddWithValue("@Name", name);

            var reader = await cmd.ExecuteReaderAsync();

            if (!reader.HasRows) return null;


            while (reader.Read())
            {
                userEntity.Name = reader["Name"].ToString();
                userEntity.Id = (int)reader["Id"];
                userEntity.DateCreated = (DateTime)reader["DateCreated"];
            }
            return userEntity;
        }
    }
}
