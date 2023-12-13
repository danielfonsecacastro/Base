using Microsoft.EntityFrameworkCore;
using ProjectBase.Core.Interfaces;
using ProjectBase.CQRS.QueryHandlers.Client;
using ProjectBase.Infrastructure.Data;
using ProjectBase.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProjectBaseContext>(c =>
               c.UseLazyLoadingProxies()
               .UseSqlServer(configuration.GetConnectionString("ProjectBaseConnection"))
           );

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AllClientHandle).Assembly));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
