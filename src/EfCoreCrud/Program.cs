using EfCoreCrud.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string databaseFile = builder.Configuration.GetConnectionString("CollegeContext")
    ?? throw new InvalidOperationException("CollegeContext is not configured.");
string databasePath = Path.Combine(builder.Environment.ContentRootPath, databaseFile);
builder.Services.AddDbContext<CollegeContext>(options =>
    options.UseSqlite($"Data Source={databasePath}"));

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
