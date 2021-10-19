using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.ServiceApp.Controllers;

namespace TMS.ServiceApp.Filters
{
    public class TransactionActionFilter :ActionFilterAttribute
    {
        IDbContextTransaction transaction;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ((BaseController)context.Controller).ActionManager.UnitOfWork.BeginTransation();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception !=null)
            {
                ((BaseController)context.Controller).ActionManager.UnitOfWork.RollbackTransation();
            }
            else
            {
                ((BaseController)context.Controller).ActionManager.UnitOfWork.CommitTransation();
            }
        }

    }
}
