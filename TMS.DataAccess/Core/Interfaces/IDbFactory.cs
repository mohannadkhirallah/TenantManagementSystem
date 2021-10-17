using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.DataAccess.Core.Interfaces
{
    public interface IDbFactory
    {
        DataContext GetDataContext { get; }
    }
}
