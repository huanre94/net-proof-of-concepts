using Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightControlService
{
    internal class LightSwitchEventSubscriber : IConsumer<LightSwitchEvent>
    {
        public async Task Consume(ConsumeContext<LightSwitchEvent> context)
        {
            var lightEvent = context.Message;
            var isSuccessful = await ControlLightAsync(lightEvent);

            if (!isSuccessful)
            {
                Console.WriteLine($"Fallo el control de luz: {lightEvent.State}");
                return;
            }

            Console.WriteLine($"Estado de luz: {lightEvent.State}");
        }

        private async Task<bool> ControlLightAsync(LightSwitchEvent lightEvent)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(2));

                if (lightEvent.State == LightState.On)
                {
                    Console.WriteLine("Prendiendo luces...");
                }
                else if (lightEvent.State == LightState.Off)
                {
                    Console.WriteLine("Apagando luces...");
                }

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
