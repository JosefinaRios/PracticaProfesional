using Microsoft.EntityFrameworkCore;
using PracticaSupervisada.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Identity.Client;
using System.Globalization;


internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var conString = builder.Configuration.GetConnectionString("BloggingDatabase") ??
          throw new InvalidOperationException("Connection string 'BloggingDatabase'" +
           " not found.");
        builder.Services.AddDbContext<PracticaPtallerContext>(options =>
              options.UseSqlServer(conString));

        builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
            options.Lockout.AllowedForNewUsers = true;
            options.User.AllowedUserNameCharacters =
             "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

        })
         .AddRoles<IdentityRole>()
          .AddEntityFrameworkStores<PracticaPtallerContext>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        using (var scope = app.Services.CreateScope()) 
        {
          var roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new[] { "Admin" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                  await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        using (var scope = app.Services.CreateScope())
        {
            var UserManager =
                  scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string email = "nestorgudino82@gmail.com";
            string password = "Casa123#";
            if(await UserManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser();
                user.UserName = email;
                user.Email = email;
               

               await  UserManager.CreateAsync(user, password);

                await UserManager.AddToRoleAsync(user, "Admin");


            }

        }


        app.Run();
     
    }
  
}