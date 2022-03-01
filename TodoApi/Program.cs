/*

Overview da API

API	                        Description	                Request body	Response body
GET /	                    Browser test, "Hello World"	None	        Hello World!
GET /todoitems	            Get all to-do items	        None	        Array of to-do items
GET /todoitems/complete	    Get completed to-do items	None	        Array of to-do items
GET /todoitems/{id}	        Get an item by ID	        None	        To-do item
POST /todoitems	            Add a new item	            To-do item	    To-do item
PUT /todoitems/{id}	        Update an existing item  	To-do item	    None
DELETE /todoitems/{id}    	Delete an item    	        None	        None

*/

/*
    Docker

    Build: docker build -t todoitemsapp .
    Run: docker run -d -p 7242:80 --name todoitems todoitemsapp

    Obs: o container Docker não utiliza HTTPS
*/

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

/* Método Hello World */
app.MapGet("/", () => "Hello World!");

/* TodoItem API */

app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync()
);

app.MapGet("/todoitems/{id}", async(int id, TodoDb db) =>
    await db.Todos.FindAsync(id) is Todo todo ? Results.Ok(todo) : Results.NotFound()
);

app.MapGet("/todoitems/complete", async(TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync()
);

app.MapPost("/todoitems", async (Todo todo, TodoDb db) => {
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todoitems/{todo.Id}", todo);
});  

app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) => {
    var todo = await db.Todos.FindAsync(id);

    if (todo is null)
        return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) => {
    if (await db.Todos.FindAsync(id) is Todo todo) {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

/* Método de teste - Weather forecast */
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

/* EXECUÇÃO DO PROGRAMA */

app.Run();

/* RECORDS E CLASSES USADAS NO PROGRAMA */
record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

/* Class Todo */
class Todo {
    public int Id {get; set;}
    public string? Name {get; set;}
    public bool IsComplete {get;set;}
}

class TodoDb : DbContext {
    public TodoDb(DbContextOptions<TodoDb> options) : base(options) {}

    public DbSet<Todo> Todos => Set<Todo>();
}