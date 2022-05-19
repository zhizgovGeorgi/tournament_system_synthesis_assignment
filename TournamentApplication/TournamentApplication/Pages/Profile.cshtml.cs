using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TournamentWebApplication.Pages
{
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            HttpContext.SignOutAsync();
            return RedirectToPage("Index");
        }
    }
}
