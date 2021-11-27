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
