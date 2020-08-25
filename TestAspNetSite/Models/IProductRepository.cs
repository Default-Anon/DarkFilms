using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspNetSite.Models
{
    public interface IProductRepository
    {
        List<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int product);
    }
}
