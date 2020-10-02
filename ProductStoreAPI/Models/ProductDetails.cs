using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStoreAPI.Models
{
    public class ProductDetails
    {
        public string productName { get; set; }
        public string categoryName { get; set; }
        public string unitName { get; set; }
        public string currencyName { get; set; }
        public decimal? price { get; set; }

        public int Id { get; set; }
    }
}