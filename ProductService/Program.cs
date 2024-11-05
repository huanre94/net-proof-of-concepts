
using ProductService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductService, ProductAdapter>();

// Add services to the container.
//builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();
//app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapGet("/products", async (IProductService _service) =>
{
    var response = await _service.GetAll();
    if (response is null) return Results.NotFound();
    return Results.Ok(response);
});
app.MapGet("/products/{id:int}", async (IProductService _service, int id) =>
{
    var response = await _service.GetById(id);
    if (response is null) return Results.NotFound();
    return Results.Ok(response);
});

app.Run();
