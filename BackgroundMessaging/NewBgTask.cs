
namespace BackgroundMessaging
{
    public class NewBgTask : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"{DateTime.Now}: Ejecutando proceso en segundo plano");
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
