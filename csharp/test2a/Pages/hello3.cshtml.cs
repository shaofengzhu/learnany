using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;

namespace MyNamespace
{
    public class HelloWorld3PageModel: PageModel
    {
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment m_env;
        public HelloWorld3PageModel(Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.m_env = env;
        }

        public string Message {
            get;
            private set;
        }

        public void OnGet()
        {
            this.Message += "Server Time:" + DateTime.Now;
            string path = Path.Combine(this.m_env.ContentRootPath, "data\\accounts.txt");
            this.Message += String.Join(", ", System.IO.File.ReadAllLines(path));
        }
    }
}