// database context class : it coordinates the "Entity framework" functionality for a data model

using Microsoft.EntityFrameworkCore;

class TodoDb : DbContext{
    public TodoDb(DbContextOptions<TodoDb> options): base(options) {}

    public DbSet<Todo> todos => Set<Todo>();
}