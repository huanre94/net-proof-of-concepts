// See https://aka.ms/new-console-template for more information

using LightControlService;
using MassTransit;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("lights", e =>
    {
        e.Consumer<LightSwitchEventSubscriber>();
    });
});

await busControl.StartAsync();

Console.WriteLine("Light control service is running. Press any key to exit.");
Console.ReadLine();

await busControl.StopAsync();
