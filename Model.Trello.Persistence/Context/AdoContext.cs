using Npgsql;
using System.Data;

namespace Model.Trello.Persistence.Context
{
    public sealed class AdoContext : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public IDbCommand Command { get; set; }


        public AdoContext(string connectionString)
        {
            Connection = new NpgsqlConnection(connectionString);
        }
        public IDbConnection Connect()
        {
            if(Connection.State == ConnectionState.Closed)
                Connection.Open();

         return Connection;
        }

        public static NpgsqlCommand CreateCommand()
        {
            return new NpgsqlCommand();
        }

        public void Dispose() => Connection.Dispose();
    }
}
