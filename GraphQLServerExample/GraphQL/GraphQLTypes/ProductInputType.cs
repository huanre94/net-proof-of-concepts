using GraphQL.Types;

namespace GraphQLServerExample.GraphQL.GraphQLTypes
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "productInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<DecimalGraphType>>("price");
        }
    }
}
