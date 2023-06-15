using GreetMeTool.BLL;
using GreetMeTool.Domain.AppSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
AppSettings appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

// Add services to the container.
builder.Services.AddSingleton(appSettings);

builder.Services.AddSingleton(typeof(IServices<>), typeof(Services<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

