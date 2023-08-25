using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/* --- configurations*/ 
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

/* --- Defining the endpoints*/

// Welcome endpoint
app.MapGet("/", ()=> "Todo APIs.");
// get all items
app.MapGet("/todoItems", async(TodoDb db)=> await db.todos.ToListAsync());

// get completed items
app.MapGet("/todoItems/complete", async(TodoDb db)=> await db.todos.Where(t => t.IsComplete).ToListAsync());

// get a one todo
app.MapGet("/todoItems/{id}", async(int id, TodoDb db)=>
           await db.todos.FindAsync(id)

           is Todo todo ? Results.Ok(todo) : Results.NotFound()
);

// make a new todo
app.MapPost("/todoItems", async(Todo todo, TodoDb db)=>{
      db.todos.Add(todo);
            await db.SaveChangesAsync();

            return Results.Created($"/todoItems/{todo.Id}", todo);
});


// update a todo
app.MapPatch("/todoItems/{id}", async(int id, Todo newTodo, TodoDb db)=>{
    var todo = await db.todos.FindAsync(id);

    if(todo is null) return Results.NotFound();

    todo.Name = newTodo.Name;
    todo.IsComplete = newTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});


// delete a certain todo
app.MapDelete("/todoItems/{id}", async(int id, TodoDb db)=>{
    if(await db.todos.FindAsync(id) is Todo todo){
        db.todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    // otherwise
    return Results.NotFound();
});

// run the application
app.Run();
