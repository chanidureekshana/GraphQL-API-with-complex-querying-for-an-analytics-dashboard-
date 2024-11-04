using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.GraphQL.Mutations;
using GraphQLAnalyticsAPI.GraphQL.Queries;
using GraphQLAnalyticsAPI.GraphQL.Types;
using HotChocolate.Features;

namespace GraphQLAnalyticsAPI.GraphQL.Schema
{
    public class AppSchema:ISchema
    {
        public AppSchema(IServiceProvider serviceProvider)
        {
            // Using Hot Chocolate to create a schema instance
            var schema = SchemaBuilder.New()
                .AddServices(serviceProvider)
                .AddQueryType(d => d.Name("Query"))
                    // .AddTypeExtension<UserQueries>()
                    // .AddTypeExtension<MetricQueries>()
                
                .AddMutationType(d => d.Name("Mutation"))
                    // .AddTypeExtension<UserMutations>()
                    // .AddTypeExtension<MetricMutations>()
                
                // Register custom types if any (UserType, MetricType, etc.)
                .AddType<UserType>()
                .AddType<MetricType>()
                
                // Enable Authorization or any other middleware, if required
                // .AddAuthorizeDirectiveType()
                
                // Register any other dependencies or configurations
                .Create();

            // Initialize the schema
            Schema = schema;
        }

        public ISchema Schema { get; }

        public IServiceProvider Services => throw new NotImplementedException();

        public ObjectType QueryType => throw new NotImplementedException();

        public ObjectType? MutationType => throw new NotImplementedException();

        public ObjectType? SubscriptionType => throw new NotImplementedException();

        public IReadOnlyCollection<INamedType> Types => throw new NotImplementedException();

        public IReadOnlyCollection<DirectiveType> DirectiveTypes => throw new NotImplementedException();

        public IDirectiveCollection Directives => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string? Description => throw new NotImplementedException();

        public IReadOnlyDictionary<string, object?> ContextData => throw new NotImplementedException();

        public IFeatureCollection Features => throw new NotImplementedException();

        public DirectiveType GetDirectiveType(string directiveName)
        {
            throw new NotImplementedException();
        }

        public Type? GetNodeIdRuntimeType(string typeName)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<ObjectType> GetPossibleTypes(INamedType abstractType)
        {
            throw new NotImplementedException();
        }

        [return: NotNull]
        public T GetType<T>(string typeName) where T : INamedType
        {
            throw new NotImplementedException();
        }

        public string Print()
        {
            throw new NotImplementedException();
        }

        public HotChocolate.Language.DocumentNode ToDocument(bool includeSpecScalars = false)
        {
            throw new NotImplementedException();
        }

        public bool TryGetDirectiveType(string directiveName, [NotNullWhen(true)] out DirectiveType? directiveType)
        {
            throw new NotImplementedException();
        }

        public bool TryGetRuntimeType(string typeName, [NotNullWhen(true)] out Type? runtimeType)
        {
            throw new NotImplementedException();
        }

        public bool TryGetType<T>(string typeName, [MaybeNullWhen(false)] out T type) where T : INamedType
        {
            throw new NotImplementedException();
        }
    }
}