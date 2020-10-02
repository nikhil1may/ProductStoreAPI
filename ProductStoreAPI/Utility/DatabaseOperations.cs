using Newtonsoft.Json.Linq;
using ProductStoreAPI.App_Start;
using ProductStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStoreAPI.Utility
{
    [ExceptionFilter]
    public class DatabaseOperations : IDatabaseOperations
    {
        private ProductStoreEntities db = new ProductStoreEntities();
        public List<ProductDetails> getAllProductDetails()
        {
            var Products = (from product in db.tbl_Product
                            join category in db.tbl_Category on product.CategoryId equals category.Id
                            join units in db.tbl_Unit on product.UnitId equals units.Id
                            join currency in db.tbl_Currency on product.CurrencyId equals currency.Id
                            select new ProductDetails
                            {
                               productName= product.ProductName,
                               categoryName= category.CategoryName,
                               unitName= units.UnitName,
                               currencyName= currency.CurrencyName,
                               price=  product.Price,
                               Id = product.Id
                            }
                            ).ToList();
            return Products;
        }

        public List<ModelCategories> getAllCategories()
        {
            var Categories = (from category in db.tbl_Category
                              select new ModelCategories
                              {
                                  Id = category.Id,
                                  CategoryName = category.CategoryName
                              }).ToList();
            return Categories;
        }

        public List<ModelUnits> getAllUnits()
        {
            

            var Units = (from unit in db.tbl_Unit
                        select new ModelUnits
                        {
                            Id = unit.Id,
                            UnitName = unit.UnitName
                        }).ToList();

            return Units;
        }

        public List<ModelCurrencies> getAllCurrencies()
        {
            var Currencies = (from currency in db.tbl_Currency
                              select new ModelCurrencies
                              {
                                  Id = currency.Id,
                                  CurrencyName = currency.CurrencyName
                              }).ToList();
            return Currencies;
        }

        public ProductDetails getProductById(int productId)
        {
            var Product = db.tbl_Product.Where(a => a.Id == productId).FirstOrDefault();
            ProductDetails productDetails = new ProductDetails();
            productDetails.Id = Product.Id;
            productDetails.currencyName = Product.CurrencyId.ToString();
            productDetails.unitName = Product.UnitId.ToString();
            productDetails.price = Product.Price;
            productDetails.categoryName = Product.CategoryId.ToString();
            productDetails.productName = Product.ProductName;
            return productDetails;
        }

        public int UpdateProductDetails(IDictionary<string, object> data)
        {
            //dynamic updateData = JObject.Parse(data);
            string Id = data["Id"].ToString();
            int searchId = Convert.ToInt32(Id);
            if (searchId != 0)
            {
                var result = db.tbl_Product.Where(p => p.Id == searchId).SingleOrDefault();
                result.ProductName = data["productName"].ToString();
                result.CategoryId = Convert.ToInt32(data["categoryName"].ToString());
                result.UnitId = Convert.ToInt32(data["unitName"].ToString());
                result.CurrencyId = Convert.ToInt32(data["currencyName"].ToString());
                result.Price = Convert.ToDecimal(data["price"].ToString());
                result.UpdatedDate = DateTime.Now;
                db.SaveChanges();
            }
            else
            {
                tbl_Product tbl_Product = new tbl_Product();
                tbl_Product.ProductName = data["productName"].ToString();
                tbl_Product.CategoryId = Convert.ToInt32(data["categoryName"].ToString());
                tbl_Product.UnitId = Convert.ToInt32(data["unitName"].ToString());
                tbl_Product.CurrencyId = Convert.ToInt32(data["currencyName"].ToString());
                tbl_Product.Price = Convert.ToDecimal(data["price"].ToString());
                tbl_Product.UpdatedDate = DateTime.Now;
                tbl_Product.AddedDate = DateTime.Now;
                db.tbl_Product.Add(tbl_Product);
                db.SaveChanges();
            }
            return 1;
        }

        public int DeleteProductDetails(int Id)
        {
            var result = db.tbl_Product.Where(p => p.Id == Id).SingleOrDefault();
            db.tbl_Product.Remove(result);
            db.SaveChanges();
            return 1;
        }

        public ModelCategories getCategoryById(int categoryId)
        {
            var Category = db.tbl_Category.Where(a => a.Id == categoryId).FirstOrDefault();
            ModelCategories categoryDetails = new ModelCategories();
            categoryDetails.Id = Category.Id;
            categoryDetails.CategoryName = Category.CategoryName.ToString();           
            return categoryDetails;
        }
        public int DeleteCategoryDetails(int Id)
        {
            var result = db.tbl_Category.Where(p => p.Id == Id).SingleOrDefault();
            db.tbl_Category.Remove(result);
            db.SaveChanges();
            return 1;
        }

        public int AddUpdateCategoryDetails(IDictionary<string, object> data)
        {
            //dynamic updateData = JObject.Parse(data);
            string Id = data["Id"].ToString();
            int searchId = Convert.ToInt32(Id);
            if (searchId != 0)
            {
                var result = db.tbl_Category.Where(p => p.Id == searchId).SingleOrDefault();
                result.CategoryName = data["CategoryName"].ToString();               
                result.DateModified = DateTime.Now;
                db.SaveChanges();
            }
            else
            {
                tbl_Category tbl_Category  = new tbl_Category();
                tbl_Category.CategoryName = data["CategoryName"].ToString();
                tbl_Category.DateAdded = DateTime.Now;
                db.tbl_Category.Add(tbl_Category);
                db.SaveChanges();
            }
            return 1;
        }

        public List<sp_SearchProductNew_Result> getProductsBySearch(IDictionary<string, object> data)
        {
            string CategoryId = data["CategoryId"].ToString();
            int categoryId = Convert.ToInt32(CategoryId);
            string productname= data["ProductName"].ToString();

            var result = db.sp_SearchProductNew(productname, categoryId).ToList();

            return result;
        }
    }
}