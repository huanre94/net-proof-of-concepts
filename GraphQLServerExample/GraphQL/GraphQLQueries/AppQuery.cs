using GraphQL.Types;
using GraphQLServerExample.GraphQL.GraphQLTypes;

namespace GraphQLServerExample.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IProductRepository repository)
        {
            Field<ListGraphType<ProductType>>("products")
                .ResolveAsync(async ctx => await repository.GetAll());

            //Field<ListGraphType<ProductType>>(
            //    "products",
            //    resolve: context => repository.GetAll()
            //);
        }
    }
}
