using Model.Trello.Domain.Interface;
using System.Data;

namespace Model.Trello.Persistence.Repositories
{
    public class UnitOfWorkAdo : IUnitOfWorkADO
    {
        private readonly IAdoContext _context;

        public UnitOfWorkAdo(IAdoContext context)
        {
            _context = context;
        }

        public IDbTransaction BeginTrasaction()
        {
            if(_context.Connection.State == ConnectionState.Open)
            {
                _context.Connection.Close();
            }
                

            _context.Connection.Open();

            return _context.Transaction = _context.Connection.BeginTransaction();

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
        public void Dispose()
        {
            _context.Transaction?.Dispose();
            _context.Connection?.Dispose();
        }
    }
}
