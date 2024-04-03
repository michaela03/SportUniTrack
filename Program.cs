using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportUniTrack.Data;

var builder = WebApplication.CreateBuilder(args);

// ???????? ?? ?????? ??? ??????????.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<SignInManager<IdentityUser>>();

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
}).AddCookie();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("RequireAdminRole",
//         policy => policy.RequireRole("adminRoleName"));
//});

var app = builder.Build();

//// ???????? ???? "teacherRoleId"
//using (var scope = app.Services.CreateScope())
//{
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//    // ????????? ????????
//    dbContext.Database.Migrate();

//    // ????????? ? ???????? ?????? "teacherRoleId"
//    if (!await roleManager.RoleExistsAsync("teacherRoleId"))
//    {
//        await roleManager.CreateAsync(new IdentityRole("teacherRoleId"));
//    }

//    // ????????? ???? ???????????? ?? ??????? ? ?????? "teacherRoleId" ? ?? ????????, ??? ??
//    var teacherEmail = "teacher@fmi.pu";
//    var teacherExists = await userManager.FindByEmailAsync(teacherEmail);
//    if (teacherExists == null)
//    {
//        var teacherUser = new IdentityUser { UserName = teacherEmail, Email = teacherEmail };
//        var result = await userManager.CreateAsync(teacherUser, "I,~KYP3@o(87");
//        if (result.Succeeded)
//        {
//            await userManager.AddToRoleAsync(teacherUser, "teacherRoleId");
//        }
//    }
//}


// ????????????? ?? ????????? ?? HTTP ??????.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
