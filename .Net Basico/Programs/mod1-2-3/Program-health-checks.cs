// //helth chceks
// using HealthChecks.UI.Client;
// using Microsoft.AspNetCore.Diagnostics.HealthChecks;
// using Microsoft.Extensions.Diagnostics.HealthChecks;

// var builder = WebApplication.CreateBuilder(args);
// builder.Services
//     .AddHealthChecksUI()
//     .AddInMemoryStorage();
// // builder.Services.AddHealthChecks();
// // builder.Services.AddHealthChecks()
// //     .AddCheck("Disks", () =>
// //     {
// //         const long minDiskSpace = 10_000_000_000; // 10 GB
// //         foreach (var drive in DriveInfo.GetDrives())
// //         {
// //             if (drive.AvailableFreeSpace < minDiskSpace)
// //             {
// //                 return HealthCheckResult.Degraded(
// //                     $"Drive {drive.Name} free space is below {minDiskSpace} bytes");
// //             }
// //         }
// //         return HealthCheckResult.Healthy();
// //     });
// // builder.Services.AddHealthChecks()
// //     .AddCheck<SystemDisksHealthCheck>("Disks");
//     builder.Services.AddHealthChecks()

//     .AddDiskStorageHealthCheck(opt =>
//     {
//         opt.AddDrive(driveName: "C:\\", minimumFreeMegabytes: 1000); // 1 GB
//         opt.AddDrive(driveName: "D:\\", minimumFreeMegabytes: 20_000); // 20 GB
//     }, name: "Disks")

//     .AddPrivateMemoryHealthCheck(
//         maximumMemoryBytes: 2_000_000_000, // 2 GB
//         failureStatus: HealthStatus.Degraded,
//         name: "Private memory"
//     );

// // builder.Services.AddHealthChecks()
// //   .AddSqlServer(
// //     connectionString: "(connection string)",
// //     healthQuery: "SELECT 1;",
// //     name: "SQL Server",
// //     failureStatus: HealthStatus.Degraded);

// // builder.Services.AddHealthChecks()
// //     .AddUrlGroup(new Uri("http://httpbin.org/status/200"), name: "httpbin API");


//     // builder.services Para encadenarlos
//     // .AddHealthChecks()
//     // .AddDiskStorageHealthCheck(...)
//     // .AddSqlServer(...)
//     // .AddRedis(...);
// var app = builder.Build();
// // app.MapHealthChecks("/health");
// app.MapHealthChecks("/health", new HealthCheckOptions()
// {
//     Predicate = _ => true,
//     ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
// });

// app.MapHealthChecksUI();
// app.Run();