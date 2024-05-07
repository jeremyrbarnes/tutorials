
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

var todos = new List<Todo>();

app.MapGet("/todos{id}", (int id) =>
{
    var targetTodo = todos.SingleOrDefault(x => x.Id == id);
    return targetTodo is null
        ? NotFoundResult()
        : OkResult(targetTodo);
}).WithName("GetTodo");


app.MapPost("/todos", (Todo todo) =>
{
    if (todo is null) return Results.BadRequest();
        todos.Add(todo);
    return TypedResults.Created($"/todos/{todo.Id}", todo);
}).WithName("CreateTodo");

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

public record Todo(int Id, string Name, DateTime DueDate, bool IsCompleted);