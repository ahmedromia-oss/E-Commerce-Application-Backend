using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.Products
{
    public interface IProduct
    {
        public IEnumerable<Product> GetProducts();
        public Product CreateProduct(ProductViewModel product , int id);
        public Product DeltePRoduct(int id);
        public Product EditProduct(int id , Product product);
    }
}
