using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace TestLoginNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            WebApplication app = builder.Build();
            app.UseStaticFiles();
            // add UseDefaultFiles so that when the user navigate to "/", the "/index" will be used.
            app.UseDefaultFiles();
            app.MapRazorPages();
            app.Run();
        }
    }
}
