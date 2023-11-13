using Model.Trello.Domain.Interface;
using System.Data;

namespace Model.Trello.Persistence.Context
{
    public sealed class AdoContext : IAdoContext
    {
        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; set; }

        public AdoContext(IDbConnection connection)
        {
            Connection = connection;
        }
    }
}
