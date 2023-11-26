using Portfolio.Services;

namespace Portfolio;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string gitHubToken = builder.Configuration["GitHubToken"];
        string githubUsername = builder.Configuration["GitHubUserName"];

        // Add services to the container.
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        builder.Services.AddScoped<IGitHubService, GitHubService>(s => new GitHubService(githubUsername, gitHubToken));

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
    }
}
