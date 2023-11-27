using LR11.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(provider => new LogActionFilter("./Logs/Logs.txt"));
builder.Services.AddScoped(provider => new UniqueUsersFilter("./Logs/Users_Logs.txt"));
builder.Services.AddMvc(options =>
{
    options.Filters.AddService<LogActionFilter>();
    options.Filters.AddService<UniqueUsersFilter>();
});

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
