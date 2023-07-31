using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Todo Apis!");

// get all todo items
app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.Run();
