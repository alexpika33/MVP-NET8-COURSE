public class MyBackgroundService : BackgroundService
{
    private readonly ILogger<MyBackgroundService> _logger;

    public MyBackgroundService(ILogger<MyBackgroundService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        for (var i = 1; !stoppingToken.IsCancellationRequested; i++)
        {
            _logger.LogInformation($"Loop #{i}");
            await Task.Delay(60*1000, stoppingToken);
        }
    }
}
