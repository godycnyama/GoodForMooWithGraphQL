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
    public class CustomerMutations
    {
        private readonly ICustomersService _customersService;
        public CustomerMutations([Service]ICustomersService customersService)
        {
            this._customersService = customersService;
        }

        public async Task<Customer> CreateCustomer(CreateCustomerInput createCustomerInput)
        {
            try
            {
              Customer _customer =  await _customersService.AddCustomer(createCustomerInput);
                return _customer;
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

        public async Task<Customer> UpdateCustomer(int id, UpdateCustomerInput updateCustomerInput)
        {
            try
            {
                Customer _customer = await _customersService.UpdateCustomer(id, updateCustomerInput);
                return _customer;
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

        public async Task<Customer> DeleteCustomer(int id)
        {
            try
            {
                Customer _customer = await _customersService.DeleteCustomer(id);
                return _customer;
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
