// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using GrpcExample;

//using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
//{
//    var client = new Greeter.GreeterClient(channel);
//    var reply = await client.SayHelloAsync(new HelloRequest { Name = "Hugo" });
//    Console.WriteLine("Greeting: " + reply.Message);
//    Console.ReadKey();
//}


using (var channel = GrpcChannel.ForAddress("http://localhost:5199"))
{
    var client = new Products.ProductsClient(channel);
    var reply = await client.GetAllAsync(new ProductRequest());
    Console.WriteLine($"Id: {reply.Id} \nNombre: {reply.Name}\n");
}