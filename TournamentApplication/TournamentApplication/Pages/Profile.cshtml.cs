using LogicLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace TournamentWebApplication.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        public User user;
        IUserManger userManger;
        IMatchManager mManger;

        public ProfileModel(IUserManger userManger, IMatchManager mManger)
        {
            this.userManger = userManger;
            this.mManger = mManger;
        }
        public void OnGet()
        {
            user = userManger.GetUserByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value);
        }

        public IActionResult OnPost()
        {
            HttpContext.SignOutAsync();
            return RedirectToPage("Index");
        }
    }
}
