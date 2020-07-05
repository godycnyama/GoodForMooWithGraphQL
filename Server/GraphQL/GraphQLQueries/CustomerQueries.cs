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
    public class CustomerQueries
    {
        private readonly ICustomersService _customersService;
        public CustomerQueries([Service]ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [UseFirstOrDefault]
        [UseSelection]
        public IQueryable<Customer> GetCustomerByID(int id) =>
            _customersService.GetCustomerByID(id);

        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> Customers => _customersService.GetAllCustomers();
    }
}
