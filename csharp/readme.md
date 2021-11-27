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
        Console.WriteLine(DateTime.Now);
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


# Hello world with dynamic data using Model
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

3. Add a page hello2.cshtml
The .cshtml means the C# HTML.

The page could be very simple.
```
@page
@model MyNamespace.HelloWorld2PageModel

<html>
    <head>
        <title>Hello, Dynamic</title>
    </head>
    <body>
        @Model.Message
    </body>
</html>
```

4. Add the page model, hello2.cshtml.cs file.
```CSharp
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyNamespace
{
    public class HelloWorld2PageModel: PageModel
    {
        public HelloWorld2PageModel()
        {
            this.Message = "Default Message";
        }

        public string Message {
            get;
            private set;
        }

        public void OnGet()
        {
            this.Message += "Server Time:" + DateTime.Now;
        }
    }
}
```

# Login
As most of the website requires login. We will create a simple website that requires user's login. For example, if the user access http://contoso.com/ and the user has not login yet, the server will redirect the browser to the http://contoso.com/login page, where the user input login name and password. The /login page will read the login name and password, compare it with the information stored in the database. For this excerse, we will use a very simple txt file to store the user's user name and password. Please note that the real world application will have much complicated system to valid user name and password.

1. Create a folder named 'testlogin'
2. In the new folder, create 'testlogin.csproj' file, whose content is
```xml
<Project Sdk="Microsoft.Net.Sdk.Web">
    <PropertyGroup>
        <TargetFramework>net6.0</TargetFramework>
        <OutputType>Exe</OutputType>
    </PropertyGroup>
</Project>
```
3. Create Program.cs, which will launch the website
```CSharp
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
```

4. Create a folder 'Pages'
5. Create a index.cshtml and index.cshtml.cs file under the 'Pages'. The index.cshtml will display the curent user's login name. In the index.cshtml.cs, it will check whether there is a cookie. If there is no cookie, then redirect to the login page.
```cshtml
@page
@model TestLoginNamespace.IndexModel

<html>
    <head>
        <title>Home Page</title>
    </head>
    <body>
        You are @Model.UserLogin
    </body>
</html>
```
In the above cshtml page, it reference the model TestLoginNamespace.IndexModel. It also render the @Model.UserLogin on the page.


```CSharp
using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestLoginNamespace
{
    public class IndexModel: PageModel
    {
        public string UserLogin 
        {
            get;
            set;
        }
        public IActionResult OnGet()
        {
            this.UserLogin = this.Request.Cookies["UserLogin"];
            if (String.IsNullOrEmpty(this.UserLogin))
            {
                return RedirectToPage("login");
            }
            
            return Page();
        }
    }
}
```
The IndexModel get the UserLogin from the Request.Cookies, which was actually set by the login page bellow.

Please also note that OnGet() method returns IActionResult instead of "void". It's because the OnGet() could redirect to another page.

6. Create login.cshtml and login.cshtml.cs. The login page will have a form and input fields.
```cshtml
@page
@model TestLoginNamespace.LoginModel
<html>
    <head>
        <title>Login</title>
    </head>
    <body>
        <form method="post">
            Name: <input type="text" name="LoginName" />
            <br />
            Password: <input type="password" name="LoginPassword" />
            <br />
            @Html.AntiForgeryToken()
            <input type="submit" value="Submit" />
        </form>
        @if (Model.InvalidLogin) {
            <div>Invalid login</div>
        }
    </body>
</html>
```

The model file will get the LoginName and LoginPassword from Request.Form, do very simple validation. If the user is authenticated, then add a cookie, and redirect to the index page.

In the above page, it also uses @Html.AntiForgeryToken() to render a hidden input field. That's for security reason as ASP.NET requires that token to avoid attack.

```CSharp
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestLoginNamespace
{
    public class LoginModel: PageModel
    {
        private IWebHostEnvironment m_env;
        public LoginModel(IWebHostEnvironment env)
        {
            m_env = env;
        }

        public bool InvalidLogin
        {
            get;
            set;
        }

        public IActionResult OnPost()
        {
            string loginName = this.Request.Form["LoginName"];
            string loginPassword = this.Request.Form["LoginPassword"];
            string path = Path.Combine(this.m_env.ContentRootPath, "database\\accounts.txt");
            string[] accountData = System.IO.File.ReadAllLines(path);
            bool authenticated = false;
            for (int i = 0; i < accountData.Length; i++)
            {
                if (accountData[i].IndexOf(loginName) >= 0)
                {
                    authenticated = true;
                    break;
                }
            }

            if (authenticated)
            {
                Response.Cookies.Append("UserLogin", loginName);
                return RedirectToPage("index");
            }
            else
            {
                InvalidLogin = true;
                return Page();
            }
        }
    }
}
```

