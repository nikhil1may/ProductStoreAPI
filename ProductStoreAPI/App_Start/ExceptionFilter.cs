using ProductStoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace ProductStoreAPI.App_Start
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        private static IDatabaseOperations _databaseOperations;
        public ExceptionFilter()
        {
            GetDependentInstances();
        }

        public void GetDependentInstances()
        {
            var container = UnityConfig.Register();
            _databaseOperations = container.Resolve<IDatabaseOperations>();
        }

        public void OnException(ExceptionContext filterContext)
        {
          string route=  filterContext.RouteData.Route.ToString();
            _databaseOperations.InsertLogMessage("Error In :" + route + "  Inner Exception " + filterContext.Exception.InnerException + "Message :"+ filterContext.Exception.Message + "Stack Trace : " + filterContext.Exception.StackTrace);
            filterContext.ExceptionHandled = true;

        }
    }
}