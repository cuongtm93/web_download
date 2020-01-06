using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webdownload.Models;

namespace webdownload.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {

        private WebDownloadDbContext db = new WebDownloadDbContext();
        public IActionResult Login()
        {
            return View();
        }

        string Encode(string text)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string username, string password, bool remember)
        {
            var code = Encode(password);

            if (db.tblAccount.Count(r => r.username == username && r.password == code) < 1) return RedirectToAction("Login");

            var user = db.tblAccount.First(r => r.username == username);
            // create claims
            List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Fullname),
                    new Claim(ClaimTypes.Email, username)
                };
            // create identity
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

            // create principal
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            // sign-in
            // sign-in
            await HttpContext.SignInAsync(
                    scheme: "DemoSecurityScheme",
                    principal: principal,
                    properties: new AuthenticationProperties
                    {
                        //IsPersistent = true, // for 'remember me' feature
                        //ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                    });

            return RedirectToAction(actionName: "Index", controllerName: "Default");
        }

        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync(
             scheme: "DemoSecurityScheme");

            return RedirectToAction("Login");
        }
    }
}