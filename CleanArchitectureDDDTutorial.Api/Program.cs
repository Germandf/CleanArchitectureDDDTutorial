using CleanArchitectureDDDTutorial.Api;
using CleanArchitectureDDDTutorial.Application;
using CleanArchitectureDDDTutorial.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
