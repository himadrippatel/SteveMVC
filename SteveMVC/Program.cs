using Microsoft.EntityFrameworkCore;
using Steve.Data;
using Steve.Model;
using Steve.Service;

var builder = WebApplication.CreateBuilder(args);

#region DBContext

builder.Services.AddDbContext<SteveContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString(Constants.DefaultConnection)));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IOpenAIService, OpenAIService>();

ConfigurationJson configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile($"appsettings.json")
                .Build().Get<ConfigurationJson>();
builder.Services.AddSingleton(configuration);
#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
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
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
