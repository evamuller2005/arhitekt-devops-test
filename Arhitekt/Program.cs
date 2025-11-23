using Arhitekt.Data;
using Arhitekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;


var builder = WebApplication.CreateBuilder(args);

// nastavi spremenljivko connectionString za .useSqlServer(connectionString)
var connectionString = builder.Configuration.GetConnectionString("ArhitektContext");

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["Redis:ConnectionString"];
});


// nadomesti stari .AddDbContext
builder.Services.AddDbContext<ArhitektContext>(options =>
            options.UseSqlServer(connectionString));

// // prilagodi RequireConfirmedAccount = false in .AddRoles<IdentityRole>()
// builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
//     .AddRoles<IdentityRole>()
//     .AddEntityFrameworkStores<ArhitektContext>();
var app = builder.Build();


// Seed database using DbInitializer 
if (args.Length == 0) // ne izvajaj med migracijami
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ArhitektContext>();
        DbInitializer.Initialize(context);
    }
}

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
// app.UseAuthentication();
app.UseAuthorization();
// app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
