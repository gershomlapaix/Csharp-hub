using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using MvcMovie.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MvcMovieContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext")));

    // Configure the HTTP request pipeline.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
// else
// {
//     // use SQL server in the production
//     builder.Services.AddDbContext<MvcMovieContext>(options =>
//             options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcMovieContext")));
// }


// ------seeding
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     SeedData.Initialize(services);
// }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
