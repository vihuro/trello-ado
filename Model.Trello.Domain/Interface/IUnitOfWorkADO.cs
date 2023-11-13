using System;
using System.Data;

namespace Model.Trello.Domain.Interface
{
    public interface IUnitOfWorkADO : IDisposable
    {
        IDbTransaction BeginTrasaction();
        void Commit();
        IDbCommand CreateCommad();
        void RollBack();
    }
}
