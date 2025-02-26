using System.Reflection;
using AircraftWeb.Components;
using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.SpecifiedRepositories;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();
var conf = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AircraftContext>(options =>
{
    options.UseSqlite(conf.GetConnectionString("Aircraft"),
        sqliteOptions =>
        {
            sqliteOptions.MigrationsAssembly(assembly.FullName);
        });
});

builder.Services.AddScoped<IRepository<Aircraft>, AircraftRepository>();
builder.Services.AddScoped<IRepository<Mercenary>, MercenaryRepository>();
builder.Services.AddScoped<IRepository<AircraftCrews>, AircraftCrewRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
