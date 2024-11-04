using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;

namespace GraphQLAnalyticsAPI.GraphQL.Types
{
    public class MetricType:ObjectType<Metric>
    {
        protected override void Configure(IObjectTypeDescriptor<Metric> descriptor)
        {
            descriptor.Field(m=>m.MetricId)
            .Type<NonNullType<IntType>>()
            .Description("The Unique Id of the Metric");

            descriptor.Field(m=>m.Name)
            .Type<NonNullType<StringType>>()
            .Description("The name of the metric");

            descriptor.Field(m=>m.Value)
            .Type<FloatType>()
            .Description("The Value Of the Metric");

        }

    }
}