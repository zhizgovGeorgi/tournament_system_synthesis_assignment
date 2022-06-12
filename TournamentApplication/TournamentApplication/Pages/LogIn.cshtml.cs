using DAL;
using LogicLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace TournamentApplication.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public LogIn logIn { get; set; }

        private readonly IUserManger um;

        public LogInModel(IUserManger _userManger)
        {
            this.um = _userManger;
        }

        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (um.GetUser(logIn.Email, logIn.Password) != null)
                    {
                        User user = um.GetUser(logIn.Email, logIn.Password);

                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Email, user.Email));
                        claims.Add(new Claim(ClaimTypes.Name, user.FName));
                        claims.Add(new Claim(ClaimTypes.Surname, user.LName));
                        claims.Add(new Claim(ClaimTypes.StreetAddress, user.Adress));
                        claims.Add(new Claim(ClaimTypes.Role, user.Role));



                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                            new AuthenticationProperties
                            {
                                IsPersistent = true,
                                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                            });


                        return RedirectToPage("Index");
                    }

                }
                catch (MyException ex)
                {
                    ViewData["Message"] = ex.Message;
                }
                catch (Exception ex)
                {
                    ViewData["Message"] = ex.Message;
                }
            }
            return Page();

        }
    }
}
