using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportUniTrack.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<SignInManager<IdentityUser>>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole",
         policy => policy.RequireRole("adminRoleId"));
});

var app = builder.Build();

//add admin role
//using (var scope = app.Services.CreateScope())
//{
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//    // Apply migrations
//    dbContext.Database.Migrate();

//    //// Seed roles
//    if (!await roleManager.RoleExistsAsync("adminRoleId"))
//    {
//        await roleManager.CreateAsync(new IdentityRole("adminRoleId"));
//    }

//    // Seed admin user
//    var adminEmail = "admin@gmail.com";
//    var adminExists = await userManager.FindByEmailAsync(adminEmail);
//    if (adminExists == null)
//    {
//        var adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
//        var result = await userManager.CreateAsync(adminUser, "%0y@K[1I%59X\r\n"); // Set the password for the admin user
//        if (result.Succeeded)
//        {
//            await userManager.AddToRoleAsync(adminUser, "adminRoleId");
//        }
//    }
//}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
