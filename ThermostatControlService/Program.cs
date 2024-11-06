// See https://aka.ms/new-console-template for more information

using MassTransit;
using ThermostatControlService;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("thermostat", e =>
    {
        e.Consumer<ThermostatEventSubscriber>();
    });
});
await busControl.StopAsync();
Console.WriteLine("Thermostat control service is running. Press any key to exit.");
Console.ReadLine();
await busControl.StopAsync();