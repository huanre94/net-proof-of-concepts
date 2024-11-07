const string server = "http://localhost:5179";
const string callback = "http://localhost:5170/wh/item/new";
const string topic = "item.new";

HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
var client = new HttpClient(clientHandler);

Console.WriteLine($"Subscribing to topic {topic} with callback {callback}");
await client.PostAsJsonAsync(server + "/subscribe", new { topic, callback });


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddHttpClient

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapPost("/wh/item/new", (object payload, ILogger<Program> logger) =>
{
    logger.LogInformation("Received payload: {payload}", payload);
});


app.Run();
