// See https://aka.ms/new-console-template for more information

using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;

var schema = Schema.For(@"
  type Query {
    hello: String
  }");

var root = new { Hello = "Hello World!" };
var json = await schema.ExecuteAsync(_ =>
{
    _.Query = "{ hello }";
    _.Root = root;
});

Console.WriteLine(json);