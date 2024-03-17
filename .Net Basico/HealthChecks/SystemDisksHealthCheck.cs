using Microsoft.Extensions.Diagnostics.HealthChecks;

public class SystemDisksHealthCheck: IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
    {
        const long minDiskSpace = 10_000_000_000; // 10 GB
        var result = HealthCheckResult.Healthy();
        foreach (var drive in DriveInfo.GetDrives())
        {
            if (drive.AvailableFreeSpace < minDiskSpace)
            {
                result = HealthCheckResult.Degraded(
                    $"Drive {drive.Name} free space is below {minDiskSpace} bytes");
                break;
            }
        }
        return Task.FromResult(result);
    }
}
