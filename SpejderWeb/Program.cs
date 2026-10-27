using DeLyserrodSpejdere.Interface;
using DeLyserrodSpejdere.Repository;

namespace SpejderWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //session

            // Add services to the container.

            builder.Services.AddRazorPages();
            builder.Services.AddDistributedMemoryCache(); // gemmer chache i memorien.
            builder.Services.AddSession(Config); // sessions med en timeout op 1 min.
            builder.Services.AddScoped<ICreateAccount, CreateAccount>();
            builder.Services.AddScoped<ILoginRepo, LoginRepo>();
            builder.Services.AddScoped<IAdminLoginRepo, AdminLoginRepo>();
            builder.Services.AddScoped<IUserLoginRepo, UserLoginRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();

            /// methoder
            ///

            void Config(SessionOptions option)
            {
                option.IdleTimeout = TimeSpan.FromMinutes(1);
            }
        }
    }
}