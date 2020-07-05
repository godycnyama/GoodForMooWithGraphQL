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
    public class OrderMutations
    {
        private readonly IOrdersService _ordersService;

        public OrderMutations([Service]IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public async Task<Order> CreateOrder(CreateOrderInput createOrderInput)
        {
            try
            {
                Order _order = await _ordersService.AddOrder(createOrderInput);
                return _order;
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

        public async Task<Order> UpdateOrder(int id, UpdateOrderInput updateOrderInput)
        {
            try
            {
                Order _order = await _ordersService.UpdateOrder(id, updateOrderInput);
                return _order;
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

        public async Task<Order> DeleteOrder(int id)
        {
            try
            {
                Order _order = await _ordersService.DeleteOrder(id);
                return _order;
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
