using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Trello.Domain.Interface
{
    public interface IUnitOfWorkADO
    {
        void BeginTrasaction();
        void Commit();
        void RollBack();
    }
}
