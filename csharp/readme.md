# Install Visual Studio
We will install the free version of Visual Studio, Community. In the setup window, please select both "Web developement" and "Desktop development".

# Hello World from scratch
We will use VSCode to manually create a hello world application, before we use Visual Studio to create an application.

1. Create a folder, such as 'test1'

2. Under the folder, create a file named 'helloworld.csproj'. Its content is
```xml
<Project Sdk="Microsoft.Net.Sdk">
    <PropertyGroup>
        <TargetFramework>net6.0</TargetFramework>
        <OutputType>Exe</OutputType>
    </PropertyGroup>
</Project>
```

3. Under the folder, create a file named 'Program.cs'. Its content is
```CSharp
using System;
class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Hello, World");
    }
}
```

You will see that the code is very similar as Java. The only difference is that java.lang namespace is replaced with System namespace. The main is replaced with Main. System.out is replaced with System.Console.

4. Under the folder, run `dotnet build` to compile the project.
In Java, we need to compile each file one by one using javac. For C#, we just compile the whole project.

5. Under the folder, run `dotnet run` to run the application. You could also go to the bin\Debug\net6.0 folder and run 'helloworld.exe' to run the application.

# Hello world web from scratch
1. create folder 'test2'

2. under 'test2', create a file 'helloworld.csproj'. Its content is something like
```xml
<Project Sdk="Microsoft.Net.Sdk.Web">
    <PropertyGroup>
        <TargetFramework>net6.0</TargetFramework>
    </PropertyGroup>
</Project>
```
You may notice that there is no 
```xml
<OutputType>Exe</OutputType>
```
in the above csproj file. It's because the default OutputType of the Web app is exe. It's OK to add the OutputType if you want.

3. Add program.cs. Its content is something like
```CSharp
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
```

4. Create a folder wwwroot under the test2. That folder are for the static files.

5. Add index.html page under the wwwroot folder. Its content is very simple
```html
<html>
    <head>
        <title>Hello, World</title>
    </head>
    <body>
        Hello, World
    </body>
</html>
```

6. Build the project using `dotnet build`

7. Run the web app using `dotnet run`

8. Now, you could access the `http://localhost:5000/index.html`

# Hello world with dynamic data

We will make a very small change to support dynamic pages.

1. Update the Program.cs by support Razor pages.
```CSharp
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Services.AddRazorPages();
        WebApplication app = builder.Build();
        app.UseStaticFiles();
        app.MapRazorPages();
        app.Run();
    }
}
```
We only need to add three lines.
```
using Microsoft.Extensions.DependencyInjection;
        builder.Services.AddRazorPages();
        app.MapRazorPages();
```

2. Add a folder "Pages". Though you could use other name for the folder, it's better to use the default name "Pages".

3. Add a page hello.cshtml
The .cshtml means the C# HTML.

The page could be very simple.
```
@page
<html>
    <head>
        <title>Hello, Dynamic</title>
    </head>
    <body>
        The time on the server @DateTime.Now
    </body>
</html>
```


