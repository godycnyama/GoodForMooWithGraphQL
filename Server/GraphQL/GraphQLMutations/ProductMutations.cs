using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using GoodForMoo.Server.DataModels;
using GoodForMoo.GraphQL.GraphQLTypes;
using GoodForMoo.Server.Services;


namespace GoodForMoo.Server.GraphQL.GraphQLMutations 
{
    [ExtendObjectType(Name = "Mutation")]
    public class ProductMutations
    {
        
        private readonly IProductsService _productsService;
        public ProductMutations( [Service]IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task<Product> CreateProduct(CreateProductInput createProductInput)
        {
            try
            {
                Product _product = await _productsService.AddProduct(createProductInput);
                return _product;
            }
            catch (Exception ex)
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage(ex.Message)
                        .SetCode("CREATE_ERROR")
                        .Build());
            }
        }

        public async Task<Product> UpdateProduct(int id, UpdateProductInput updateProductInput)
        {
            try
            {
                Product _product = await _productsService.UpdateProduct(id, updateProductInput);
                return _product;
            }
            catch (Exception ex)
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage(ex.Message)
                        .SetCode("UPDATE_ERROR")
                        .Build());
            }
        }

        public async Task<Product> DeleteProduct(int id)
        {
            try
            {
                Product _product = await _productsService.DeleteProduct(id);
                return _product;
            }
            catch (Exception ex)
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage(ex.Message)
                        .SetCode("DELETE_ERROR")
                        .Build());
            }
        }
    }
}
