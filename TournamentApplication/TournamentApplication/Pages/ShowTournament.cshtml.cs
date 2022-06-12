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

        [BindProperty]
        public int idt { get; set; }

        public void OnGet(int id)
        {
            idt = Convert.ToInt32(id);
            t = tm.GetTournament(idt);
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                tm.SignForTournament(tm.GetTournament(id), um.GetUserByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value));
                return RedirectToPage("Profile");

            }
            return RedirectToPage("Index");

        }
    }
}
