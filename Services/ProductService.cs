using System.Collections.Generic;
using learn_c_sharp_mvc.Models;

namespace learn_c_sharp_mvc.Services
{
    public class ProductService : List<Product>
    {
        public ProductService()
        {
            this.AddRange(new Product[] {
                new Product() {Id = 1,Name = "Iphone",Price = 1000},
                new Product() {Id = 2,Name = "Samsung",Price = 5000},
                new Product() {Id = 3,Name = "Nokia",Price = 8000},
                new Product() {Id = 4,Name = "Sony",Price = 2000}
            });
        }
    }
}