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
    public class OrderQueries
    {
        private readonly IOrdersService _ordersService;

        public OrderQueries([Service]IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [UseFirstOrDefault]
        [UseSelection]
        public IQueryable<Order> GetOrderByID(int id) =>
            _ordersService.GetOrderByID(id);


        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Order> Orders => _ordersService.GetAllOrders();
    }
}
