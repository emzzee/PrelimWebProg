using Microsoft.EntityFrameworkCore;
using EncarnacionCoop.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EncarnacioncoopContext>(option =>
    option.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=encarnacioncoop;TrustServerCertificate=true;Trusted_Connection=True"));
// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Admin}/{action=Index}/{id?}");

app.Run();
