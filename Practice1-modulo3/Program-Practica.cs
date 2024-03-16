// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddTransient<ICalculationEngine, CalculationEngine>();
// builder.Services.AddTransient<ICalculatorServices,CalculatorServices>();
// builder.Services.AddRouting(options =>
// {
//     options.ConstraintMap.Add("valid-operation", typeof(ValidOperationConstraint));
// });
// var app = builder.Build();
// app.UseRouting();
// app.MapGet("/",()=> "Hello World!");
// // app.MapGet("/calculator/{operation}/{a}/{b}",  CalculatorHandler.Calculate );
// app.MapCalculator("/calculator/{operation:valid-operation}/{a:int}/{b:int}");

// app.Run();
// El resto de la practica , la parte 4 de formularios y antiforgery está en otra carpeta hermana de la raiz de este proyecto