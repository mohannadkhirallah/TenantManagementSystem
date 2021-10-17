using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataAccess.Core.Interfaces;

namespace TMS.DataAccess.Core.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void BeginTransation()
        {
            _dbFactory.GetDataContext.Database.BeginTransaction();
        }

        public void CommitTransation()
        {
            _dbFactory.GetDataContext.Database.CommitTransaction();
        }

        public void RollbackTransation()
        {
            _dbFactory.GetDataContext.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            _dbFactory.GetDataContext.Save();
        }
    }
}
