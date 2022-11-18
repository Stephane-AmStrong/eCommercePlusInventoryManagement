using Web.Middleware;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
using Services.Mappings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddDbContextPool<RepositoryDbContext>(dbBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    dbBuilder.UseNpgsql(connectionString);
});

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
