using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;
using HotChocolate.Types;

namespace GraphQLAnalyticsAPI.GraphQL.Types
{
    public class UserType:ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(u=>u.UserId)
            .Type<NonNullType<IntType>>()
            .Description("The Unique Id of the User");

            descriptor.Field(u=>u.Username)
            .Type<NonNullType<StringType>>()
            .Description("The Username of the user");

            descriptor.Field(u=>u.Email)
            .Type<NonNullType<StringType>>()
            .Description("The Email of the User");

            descriptor.Field(u=>u.CreatedAt)
            .Type<DateTimeType>()
            .Description("The Datetime that User created");

        }
    }
}