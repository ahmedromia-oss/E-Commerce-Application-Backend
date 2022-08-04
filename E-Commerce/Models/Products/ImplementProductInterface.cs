using E_Commerce.Models.DataBase;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;


namespace E_Commerce.Models.Products
{
    public class ImplementProductInterface : IProduct
    {
        
        private AppDBContext appDBContext;
        private readonly IHostingEnvironment hostingEnvironment;

        public ImplementProductInterface(AppDBContext appDBContext , IHostingEnvironment hostingEnvironment )
        {
            this.appDBContext = appDBContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        public Product CreateProduct(ProductViewModel product , int id)
        {

            string UniqueFileName = null;
            if(product.PhotoPath != null)
            {
               string UploadsFolder =  Path.Combine(hostingEnvironment.WebRootPath, "Images");
               UniqueFileName = Guid.NewGuid().ToString() + "_" + product.PhotoPath.FileName;
               string FilePath = Path.Combine(UploadsFolder, UniqueFileName);
                product.PhotoPath.CopyTo(new FileStream(FilePath, FileMode.Create));
                
            }

            Product product1 = new Product()
            {
                Name = product.Name,

                Price = product.Price,

                Describtion = product.Describtion,

                PhotoPath = UniqueFileName,

                category = this.appDBContext.categories.FirstOrDefault(e => e.Id == id)

                
               
               
            };

            appDBContext.Products.Add(product1);
            appDBContext.SaveChanges();
            return product1;
        }

        public Product DeltePRoduct(int id)
        {
            Product result = appDBContext.Products.FirstOrDefault<Product>(e => e.Id == id);
            appDBContext.Products.Remove(result);
            appDBContext.SaveChanges();
            return result;
        }

        public Product EditProduct(int id , Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.appDBContext.Products ;
        }
    }
       
}
