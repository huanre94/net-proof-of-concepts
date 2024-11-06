using GraphQL.Types;

namespace GraphQLServerExample.GraphQL.GraphQLTypes
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the Product");
            Field(x => x.Name).Description("The name of the Product");
            Field(x => x.Price).Description("The price of the Product");

        }
    }
}
