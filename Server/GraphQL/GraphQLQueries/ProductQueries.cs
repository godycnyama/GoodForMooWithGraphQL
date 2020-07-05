using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using GoodForMoo.Server.DataModels;
using GoodForMoo.GraphQL.GraphQLTypes;
using GoodForMoo.Server.Services;

namespace GoodForMoo.Server.GraphQL.GraphQLQueries
{
    [ExtendObjectType(Name = "Query")]
    public class ProductQueries
    {
        private readonly IProductsService _productsService;

        public ProductQueries([Service]IProductsService productsService)
        {
            _productsService = productsService;
        }

        [UseFirstOrDefault]
        [UseSelection]
        public IQueryable<Product> GetProductByID(int id) =>
            _productsService.GetProductByID(id);

        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> Products => _productsService.GetAllProducts();
    }
}
