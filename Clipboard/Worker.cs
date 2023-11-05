using System.Runtime.InteropServices;

namespace Clipboard
{
    public class Worker : BackgroundService
    {
        [DllImport("copy.dll")]
        private static extern int main();

        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var a = main();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
