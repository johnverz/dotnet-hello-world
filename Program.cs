using Microsoft.AspNetCore.Mvc;
using workspace.Data;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.StaticFiles; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

// Configure Services
builder.Services.AddControllers(); // Add controllers to the pipeline
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();


// Build the application
var app = builder.Build();
// Serve static files from wwwroot if configured
// app.UseStaticFiles();

// Configure request pipeline
app.MapControllers(); // Map controllers to URL routes

// Optional default route for an empty page (if no static files)
//app.MapGet("/", () => "Hello from the root!"); // Replace with desired content

// Run the application
app.Run();