using GraphQL.Types;
using GraphQLServerExample.GraphQL.GraphQLMutations;
using GraphQLServerExample.GraphQL.GraphQLQueries;

namespace GraphQLServerExample.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}
