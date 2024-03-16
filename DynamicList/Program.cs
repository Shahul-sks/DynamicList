using DynamicList.Controllers;
using DynamicList.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<CarContext>(item => item.UseNpgsql(config.GetConnectionString("dataconnect")));


//builder.Services.AddDbContext<CarContext>(options =>
//options.UseNpgsql(builder.Configuration.GetConnectionString("dataconnect")));

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
    pattern: "{controller=Car}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default1",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
