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