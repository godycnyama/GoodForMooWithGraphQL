using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using GoodForMoo.Server.DataAccess;
using GoodForMoo.Server.DataModels;

namespace GoodForMoo.Server.Services
{
    public class ProductsService: IProductsService
    {
        DataAccessContext db;
        public ProductsService(DataAccessContext c)
        {
            db = c;
        }

        //Get products records
        public IQueryable<Product> GetAllProducts()
        {
            return db.Products;
        }

        //Add new product record     
        public async Task<Product> AddProduct(CreateProductInput createProductInput)
        {
            //check if product already exists
            Product product = await db.Products.FirstOrDefaultAsync(i => i.ProductName == createProductInput.ProductName);
            if (product != null)
            {
                throw new Exception("Product already exists");
            }
            
            Product _product = new Product
            {
                ProductName = createProductInput.ProductName,
                UnitPrice = createProductInput.UnitPrice,
                UnitOfMeasure = createProductInput.UnitOfMeasure,
                Currency = createProductInput.Currency
            };
            await db.Products.AddAsync(_product);
            await db.SaveChangesAsync();
            return product;
        }

        //Update product record   
        public async Task<Product> UpdateProduct(int id, UpdateProductInput updateProductInput)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.ProductName = updateProductInput.ProductName;
            product.UnitPrice = updateProductInput.UnitPrice;
            product.UnitOfMeasure = updateProductInput.UnitOfMeasure;
            product.Currency = updateProductInput.Currency;

            await db.SaveChangesAsync();
            return product;
        }

        //Get product record   
        public async Task<Product> GetProduct(int id)
        {
            return await db.Products.FindAsync(id);
        }

        //Get product record   
        public IQueryable<Product> GetProductByID(int id)
        {
            return db.Products.Where(t => t.ProductID == id);
        }

        //Delete product record   
        public async Task<Product> DeleteProduct(int id)
        {
            //check if product exists
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return product;
        }
    }
}
