using Microsoft.EntityFrameworkCore;
using vesion15.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SQLDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLDBContext") ?? throw new InvalidOperationException("Connection string 'SQLDBContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//database
var connectionString = builder.Configuration.GetConnectionString("SQL");
builder.Services.AddDbContext<QLDBContext>(opptions => opptions.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
// session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IOTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
