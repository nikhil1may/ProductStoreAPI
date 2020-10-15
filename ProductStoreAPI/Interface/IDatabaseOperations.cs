using ProductStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStoreAPI.Interface
{
    public interface IDatabaseOperations
    {
        List<ProductDetails> getAllProductDetails();
        List<ModelCategories> getAllCategories();
        List<ModelUnits> getAllUnits();
        List<ModelCurrencies> getAllCurrencies();
        ProductDetails getProductById(int productId);
        int UpdateProductDetails(IDictionary<string, object> data);
        int DeleteProductDetails(int Id);
        ModelCategories getCategoryById(int categoryId);
        int DeleteCategoryDetails(int Id);
        int AddUpdateCategoryDetails(IDictionary<string, object> data);
        List<sp_SearchProductNew_Result> getProductsBySearch(IDictionary<string, object> data);
        List<ModelCategories> getCategoryByName(IDictionary<string, object> data);
        int InsertLog(IDictionary<string, object> data);
        void InsertLogMessage(string logMessage);
    }
}
