using GraphQL;
using GraphQL.Types;
using GraphQLServerExample.GraphQL.GraphQLTypes;

namespace GraphQLServerExample.GraphQL.GraphQLMutations
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IProductRepository _repository)
        {
            Field<ProductType>("addProduct")
                .Arguments(new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" })
                .ResolveAsync(async ctx => await _repository.Add(ctx.GetArgument<Product>("product")));
        }
    }
}
