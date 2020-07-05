using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using GoodForMoo.Server.DataModels;

namespace GoodForMoo.Server.GraphQL.GraphQLTypes
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Field(t => t.ProductID)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.ProductName)
                .Type<StringType>();

            descriptor.Field(t => t.UnitPrice)
                .Type<DecimalType>();

            descriptor.Field(t => t.UnitOfMeasure)
                .Type<StringType>();

            descriptor.Field(t => t.Currency)
                .Type<StringType>();
        }

    }
}
