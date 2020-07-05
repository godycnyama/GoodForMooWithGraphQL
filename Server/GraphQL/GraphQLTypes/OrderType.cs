using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using GoodForMoo.Server.DataModels;
using GoodForMoo.Server.Services;

namespace GoodForMoo.GraphQL.GraphQLTypes
{
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor.Field(t => t.OrderID)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.CustomerID)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Customer)
                .Type<CustomerType>();

            descriptor.Field(t => t.SubTotal)
                .Type<DecimalType>();

            descriptor.Field(t => t.Tax)
                .Type<DecimalType>();

            descriptor.Field(t => t.Total)
                .Type<DecimalType>();

            descriptor.Field(t => t.DeliveryAddress)
                .Type<StringType>();

            descriptor.Field(t => t.DeliveryAddress)
                .Type<StringType>();

            descriptor.Field(t => t.DeliveryDate)
                .Type<StringType>();

            descriptor.Field(t => t.Currency)
                .Type<StringType>();

            descriptor.Field(t => t.OrderStatus)
                .Type<StringType>();

            descriptor.Field(t => t.OrderDetails)
                .Type<ListType<OrderDetailType>>();
        }

    }
}
