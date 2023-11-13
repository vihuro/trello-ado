using Npgsql;


namespace Model.Trello.Persistence.Migrations
{
    public static class CreateDataBase
    {
        public static void CreateTable(string database,string connectionString)
        {
            var connection = new NpgsqlConnection(connectionString);

            connection.Open();

            using var cmd = new NpgsqlCommand("SELECT 1 FROM pg_database WHERE datname = @DatabaseName", connection);
            cmd.Parameters.AddWithValue("@DatabaseName", database);

            var tableExists = cmd.ExecuteScalar();

            if (tableExists == null)
            {
                cmd.CommandText = $"CREATE DATABASE {database}";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
