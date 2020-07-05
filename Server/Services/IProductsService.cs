using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodForMoo.Server.DataModels;

namespace GoodForMoo.Server.Services
{
   public interface IProductsService
    {
        public IQueryable<Product> GetAllProducts();
        public Task<Product> AddProduct(CreateProductInput createProductInput);
        public Task<Product> UpdateProduct(int id, UpdateProductInput updateProductInput);
        public Task<Product> GetProduct(int id);
        public IQueryable<Product> GetProductByID(int id);
        public Task<Product> DeleteProduct(int id);
    }
}
