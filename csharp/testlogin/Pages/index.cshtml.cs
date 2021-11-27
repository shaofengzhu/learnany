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
