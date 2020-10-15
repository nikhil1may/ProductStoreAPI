using ProductStoreAPI.App_Start;
using ProductStoreAPI.Interface;
using ProductStoreAPI.ProductStoreService;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace ProductStoreAPI.Controllers
{
    [ExceptionFilter]
   
    public class EditController : ApiController
    {
        [Dependency]
        private static IDatabaseOperations _databaseOperations;
        public EditController(IDatabaseOperations databaseOperations)
        {
            _databaseOperations = databaseOperations;
        }

        [HttpPost]
        [Route("api/Edit/UpdateProduct")]
        public IHttpActionResult UpdateProduct([FromBody]ExpandoObject jsonString)
        {
            var keyValuePairs = ((System.Collections.Generic.IDictionary<string, object>)jsonString);
            
            _databaseOperations.UpdateProductDetails(keyValuePairs);
            return Json("");

        }


        [HttpPost]
        [Route("api/Edit/AddUpdateCategory")]
        public IHttpActionResult AddUpdateCategory([FromBody]ExpandoObject jsonString)
        {
            var keyValuePairs = ((System.Collections.Generic.IDictionary<string, object>)jsonString);

            _databaseOperations.AddUpdateCategoryDetails(keyValuePairs);
            return Json("");

        }
        [HttpPost]
        [Route("api/Edit/SearchProduct")]
        public IHttpActionResult GetProductBySearchCriteria([FromBody]ExpandoObject searchCriteria)
        {
            var keyValuePairs = ((System.Collections.Generic.IDictionary<string, object>)searchCriteria);
            var data = _databaseOperations.getProductsBySearch(keyValuePairs);

            return Json(data);
        }

        [HttpPost]
        [Route("api/Edit/SearchCategory")]
        public IHttpActionResult GetCategoryByName([FromBody]ExpandoObject searchCriteria)
        {
            var keyValuePairs = ((System.Collections.Generic.IDictionary<string, object>)searchCriteria);
            var data = _databaseOperations.getCategoryByName(keyValuePairs);

            return Json(data);
        }

        [HttpPost]
        [Route("api/Edit/ManageLog")]
        public IHttpActionResult InsertLog([FromBody]ExpandoObject Values)
        {
            var keyValuePairs = ((System.Collections.Generic.IDictionary<string, object>)Values);
            var data = _databaseOperations.InsertLog(keyValuePairs);

            return Json(data);
        }
    }
}
