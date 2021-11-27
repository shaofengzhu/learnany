using System;
using Microsoft.AspNetCore.Builder;

class Program {
    public static void Main(String[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        WebApplication app = builder.Build();
        app.UseStaticFiles();
        app.Run();
    }
}