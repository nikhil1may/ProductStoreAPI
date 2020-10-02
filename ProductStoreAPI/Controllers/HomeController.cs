using ProductStoreAPI.App_Start;
using ProductStoreAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
namespace ProductStoreAPI.Controllers
{
    [ExceptionFilter]
    public class HomeController : Controller
    {
        private static IDatabaseOperations _databaseOperations;
        public HomeController()
        {
            GetDependentInstances();
        }

        public void GetDependentInstances()
        {
            var container = UnityConfig.Register();
            _databaseOperations = container.Resolve<IDatabaseOperations>();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

       
        public JsonResult GetAllProducts()
        {
            var data = _databaseOperations.getAllProductDetails();

            return Json(data , JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult GetProductById(int Id)
        {
            var data = _databaseOperations.getProductById(Id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult GetAllUnits()
        {
            var data = _databaseOperations.getAllUnits();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult GetAllCategories()
        {
            var data = _databaseOperations.getAllCategories();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult GetAllCurrencies()
        {
            var data = _databaseOperations.getAllCurrencies();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteProduct(int Id)
        {
            var data = _databaseOperations.DeleteProductDetails(Id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCategoryById(int Id)
        {
            var data = _databaseOperations.getCategoryById(Id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCategory(int Id)
        {
            var data = _databaseOperations.DeleteCategoryDetails(Id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

      
    }
}
