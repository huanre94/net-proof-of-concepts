using GraphQL;
using GraphQL.Server.Ui.Playground;
using GraphQLServerExample;
using GraphQLServerExample.GraphQL.GraphQLSchema;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GQLContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<AppSchema>();
builder.Services.AddGraphQL(b => b
    //.AddSchema<AppSchema>()
    .AddGraphTypes(Assembly.GetExecutingAssembly())
    .AddSystemTextJson());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDeveloperExceptionPage();
//app.UseWebSockets();
app.UseGraphQL<AppSchema>();
app.UseGraphQLPlayground("/", new PlaygroundOptions { GraphQLEndPoint = "/graphql", SubscriptionsEndPoint = "/graphql" });

app.UseHttpsRedirection();

app.MapGet("/products", async (IProductRepository _repo) =>
{
    var response = await _repo.GetAll();
    return Results.Ok(response);
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

