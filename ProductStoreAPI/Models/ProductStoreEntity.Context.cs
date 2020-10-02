﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductStoreAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProductStoreEntities : DbContext
    {
        public ProductStoreEntities()
            : base("name=ProductStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Category> tbl_Category { get; set; }
        public virtual DbSet<tbl_Currency> tbl_Currency { get; set; }
        public virtual DbSet<tbl_Product> tbl_Product { get; set; }
        public virtual DbSet<tbl_Unit> tbl_Unit { get; set; }
    
        public virtual ObjectResult<sp_SearchProduct_Result> sp_SearchProduct(string productName, Nullable<int> category)
        {
            var productNameParameter = productName != null ?
                new ObjectParameter("ProductName", productName) :
                new ObjectParameter("ProductName", typeof(string));
    
            var categoryParameter = category.HasValue ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchProduct_Result>("sp_SearchProduct", productNameParameter, categoryParameter);
        }
    
        public virtual ObjectResult<sp_SearchProductNew_Result> sp_SearchProductNew(string productName, Nullable<int> category)
        {
            var productNameParameter = productName != null ?
                new ObjectParameter("ProductName", productName) :
                new ObjectParameter("ProductName", typeof(string));
    
            var categoryParameter = category.HasValue ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchProductNew_Result>("sp_SearchProductNew", productNameParameter, categoryParameter);
        }
    }
}
