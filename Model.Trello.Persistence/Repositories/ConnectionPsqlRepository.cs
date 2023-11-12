using Model.Trello.Domain.Interface;
using System.Data;

namespace Model.Trello.Persistence.Repositories
{
    public class ConnectionPsqlRepository 
    {
        protected IDbConnection _connection;

        public ConnectionPsqlRepository(IDbConnection connection)
        {
            _connection = connection;

            _connection.Open();
        }

    }
}
