using System.Data;

namespace Model.Trello.Domain.Interface
{
    public interface IAdoContext
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; set; }
    }
}
