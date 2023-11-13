using Model.Trello.Domain.Interface;
using System.Data;

namespace Model.Trello.Persistence.Repositories
{
    public class UnitOfWorkAdo : IUnitOfWorkADO , IDisposable
    {
        private readonly IAdoContext _context;

        public UnitOfWorkAdo(IAdoContext context)
        {
            _context = context;
        }

        public void BeginTrasaction()
        {
            _context.Connection.Open();
            _context.Transaction = _context.Connection.BeginTransaction();
        }

        public IDbCommand CreateCommad()
        {
            return _context.Connection.CreateCommand();
        }

        public void Commit()
        {
            _context.Transaction.Commit();
            Dispose();
        }

        public void RollBack()
        {
            _context.Transaction.Rollback();
            Dispose();
        }
        public void Dispose() => _context.Transaction?.Dispose();

    }
}
