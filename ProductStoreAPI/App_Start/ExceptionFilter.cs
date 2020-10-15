using ProductStoreAPI.Interface;
using ProductStoreAPI.Models;
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
       
        private ProductStoreEntities db = new ProductStoreEntities();   

        public void OnException(ExceptionContext filterContext)
        {
          string route=  filterContext.RouteData.Route.ToString();
            string logMessage= "Error In :" + route + "  Inner Exception " + filterContext.Exception.InnerException + "Message :"+ filterContext.Exception.Message + "Stack Trace : " + filterContext.Exception.StackTrace;
           
                tbl_Error tblError = new tbl_Error();
                tblError.ErrorMessage = logMessage;
                tblError.ErrorTime = DateTime.Now;
                db.tbl_Error.Add(tblError);
                db.SaveChanges();
           

            filterContext.ExceptionHandled = true;

        }
    }
}