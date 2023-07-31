using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Todo Apis!");

// get all todo items
app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

// get completed todos
app.MapGet("/todoitems/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

// get a one todo
app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

//  add a new todo
app.MapPost("/todoitems", async(Todo todo, TodoDb db)=>{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
});
app.Run();
