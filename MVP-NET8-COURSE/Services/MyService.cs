public class MyService
{
    private readonly ILogger<MyService> _logger;
    private readonly ILogger _anotherLogger;

    // public MyService(ILogger<MyService> logger)
    // {
    //     _logger = logger;
    // }
    public MyService(ILoggerFactory loggerFactory,ILogger<MyService> logger)
    {
        _logger = logger;
        _anotherLogger = loggerFactory.CreateLogger("AnotherLogger");
    }
    public void DoWork()
    {
        _logger.LogInformation("Doing work");
        _anotherLogger.LogInformation("Doing work in anotherlogger");
    }
}