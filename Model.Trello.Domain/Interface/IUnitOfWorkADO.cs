using System;
using System.Data;

namespace Model.Trello.Domain.Interface
{
    public interface IUnitOfWorkADO
    {
        void BeginTrasaction();
        void Commit();
        IDbCommand CreateCommad();
        void RollBack();
    }
}
