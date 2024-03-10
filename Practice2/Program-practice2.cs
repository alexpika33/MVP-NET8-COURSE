// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddTransient<ICalculatorServices,CalculatorServices>();
// builder.Services.AddTransient<ICalculationEngine,CalculationEngine>();
// builder.Logging.SetMinimumLevel(LogLevel.None);
// var app = builder.Build();
// app.UseStatusCodePagesWithReExecute("/error/show/{0}");

// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/error/show/500");
// }
// app.UseCustomErrorPages();

// app.UseCalculator("/calculator");

// app.Run();