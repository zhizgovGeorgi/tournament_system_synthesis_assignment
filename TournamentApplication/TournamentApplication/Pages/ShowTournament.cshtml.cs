using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace TournamentWebApplication.Pages
{
    public class ShowTournamentModel : PageModel
    {
        ITournamentManager tm;
        IUserManger um;
        public ShowTournamentModel(ITournamentManager tm, IUserManger um)
        {
            this.tm = tm;
            this.um = um;
        }



        public Tournament t;


        public void OnGet(int id)
        {
            t = tm.GetTournament(id);
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                if (tm.SignForTournament(tm.GetTournament(id), um.GetUserByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value)) is true)
                {
                    return RedirectToPage("Profile");
                }
            }
            return RedirectToPage("Index");
        }
    }
}
