var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Session needs a cache to keep its values on the server.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Must come before the endpoints that read HttpContext.Session.
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Edit}/{id?}");

app.Run();
