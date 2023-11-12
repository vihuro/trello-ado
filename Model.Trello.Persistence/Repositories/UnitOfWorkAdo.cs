using Model.Trello.Domain.Interface;
using Model.Trello.Persistence.Context;


namespace Model.Trello.Persistence.Repositories
{
    public class UnitOfWorkAdo : IUnitOfWorkADO
    {
        private readonly AdoContext _context;

        public UnitOfWorkAdo(AdoContext context)
        {
            _context = context;
        }

        public void BeginTrasaction()
        {
            _context.Transaction = _context.Connection.BeginTransaction();
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
