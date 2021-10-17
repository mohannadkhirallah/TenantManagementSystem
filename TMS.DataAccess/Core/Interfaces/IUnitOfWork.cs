using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.DataAccess.Core.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransation();
        void RollbackTransation();
        void CommitTransation();
        void SaveChanges();
    }
}
