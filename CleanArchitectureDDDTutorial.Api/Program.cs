using CleanArchitectureDDDTutorial.Api.Errors;
using CleanArchitectureDDDTutorial.Application;
using CleanArchitectureDDDTutorial.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
//builder.Services.AddControllers(o => o.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");
/*
app.Map("/error", (HttpContext httpContext) =>
{
    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    return Results.Problem();
});
*/
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
