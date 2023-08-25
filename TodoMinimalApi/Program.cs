using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/* --- configurations*/ 
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

/* --- Defining the endpoints*/

/*
   This version 2 uses TypedResults API instead of Results. It provides advantages like 
   testability and automatically returning the response type metadata for OpenAPI to describe the endpoint
*/

var todoItems = app.MapGroup("/todoItems");
todoItems.MapGet("/", GetAlltodos);
todoItems.MapGet("/complete", GetCompletetodos);
todoItems.MapGet("/{id}", GetTodo);
todoItems.MapPost("/", CreateTodo);
// todoItems.MapPut("/{id}", UpdateTodo);
todoItems.MapPatch("/{id}", UpdateTodo);
todoItems.MapDelete("/{id}", DeleteTodo);

// run the application
app.Run();


/* ----- define the handler methods*/

// get all todods
static async Task<IResult> GetAlltodos(TodoDb db){
    return TypedResults.Ok(await db.todos.ToArrayAsync());
}

// get completed todos
static async Task<IResult> GetCompletetodos(TodoDb db){
    return TypedResults.Ok(await db.todos.Where(t => t.IsComplete).ToListAsync());
} 

// get a one todo
static async Task<IResult> GetTodo(int id, TodoDb  db){
    
    Todo anyTodo = await db.todos.FindAsync(id);

    return anyTodo is Todo todo ? TypedResults.Ok(todo): TypedResults.NotFound();
}


// create a todo
static async Task<IResult> CreateTodo(Todo todo, TodoDb db)
{
    db.todos.Add(todo);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/todoitems/{todo.Id}", todo);
}

// update a todo
static async Task<IResult> UpdateTodo(int id, Todo inputTodo, TodoDb db)
{
    var todo = await db.todos.FindAsync(id);

    if (todo is null) return TypedResults.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return TypedResults.NoContent();
}


// delete a todo
static async Task<IResult> DeleteTodo(int id, TodoDb db)
{
    if (await db.todos.FindAsync(id) is Todo todo)
    {
        db.todos.Remove(todo);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}





/*
 // VERSION1
 
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
 
*/