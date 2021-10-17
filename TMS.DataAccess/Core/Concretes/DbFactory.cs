using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataAccess.Core.Interfaces;

namespace TMS.DataAccess.Core.Concretes
{
    public class DbFactory : IDbFactory, IDisposable
    {
        private readonly DataContext _dataContext;

        public DbFactory(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        public DataContext GetDataContext
        {
            get
            {
                return _dataContext;
            }
        }

        #region Disposing

        private bool isDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                }
            }
            isDisposed = true;
        }

        #endregion
    }
}
