using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;

public class EmailSender: IServer
{
    private readonly IConfiguration _configuration;
    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IFeatureCollection Features => throw new NotImplementedException();

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task SendAsync(string text, string target)
    {
        var smtpServer = _configuration["SmtpServer"];
        var smtpCredentials = _configuration["SmtpCredentials"];
        var sender = _configuration["Sender"];
        return Task.CompletedTask;
        
    }

    public Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken) where TContext : notnull
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
