using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;

namespace GraphQLAnalyticsAPI.GraphQL.Types
{
    public class EventType:ObjectType<Event>
    {
        protected override void Configure(IObjectTypeDescriptor<Event> descriptor)
        {
            descriptor.Field(e=>e.EventId).
            Type<NonNullType<IntType>>()
            .Description("The Identity Key of Event");

            descriptor.Field(e=>e.Details)
            .Type<NonNullType<StringType>>()
            .Description("The Details of event");

            descriptor.Field(e=>e.EventType)
            .Type<NonNullType<StringType>>()
            .Description("The Event Type of Event");

            descriptor.Field(e=>e.TimeStamp)
            .Type<DateTimeType>()
            .Description("The TimeStamp of event");

            // descriptor.Field(e=>e.)
        }
    }
}