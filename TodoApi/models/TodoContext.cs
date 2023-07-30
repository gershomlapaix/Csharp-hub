/*
  Database context coordinates an Entity Framework functionality fot a data nodel
*/
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}