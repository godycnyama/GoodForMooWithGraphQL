using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using GoodForMoo.Server.DataModels;

namespace GoodForMoo.GraphQL.GraphQLTypes
{
    public class CustomerType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.Field(t => t.CustomerID)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.CustomerName)
                .Type<StringType>();

            descriptor.Field(t => t.PhysicalAddress)
                .Type<StringType>();

            descriptor.Field(t => t.Town)
                .Type<StringType>();

            descriptor.Field(t => t.PostalCode)
                .Type<StringType>();

            descriptor.Field(t => t.Province)
                .Type<StringType>();

            descriptor.Field(t => t.Telephone)
                .Type<StringType>();

            descriptor.Field(t => t.Mobile)
                .Type<StringType>();

            descriptor.Field(t => t.Email)
                .Type<StringType>();
        }

    }
}
