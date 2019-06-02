using System;
using System.Collections.Generic;

namespace WorkingWithVisualStudio.Models
{
    public class ProductRepository
    {
        private static ProductRepository sharedRepository = new ProductRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();
        public static ProductRepository SharedRepository => new ProductRepository();

        public ProductRepository()
        {
            var initialProducts = new[] {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };

            foreach (var p in initialProducts)
            {
                AddProduct(p);
            }

            products.Add("Error", null);
        }

        public IEnumerable<Product> Products => products.Values;
        public void AddProduct(Product p) => products.Add(p.Name, p);
       
    }
}
