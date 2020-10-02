using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProductStoreAPI.App_Start
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ExceptionFilter));
        public void OnException(ExceptionContext filterContext)
        {
          string route=  filterContext.RouteData.Route.ToString();
            logger.Error("Error In :" + route + "  Inner Exception " + filterContext.Exception.InnerException + "Message :"+ filterContext.Exception.Message + "Stack Trace : " + filterContext.Exception.StackTrace);
            filterContext.ExceptionHandled = true;

        }
    }
}