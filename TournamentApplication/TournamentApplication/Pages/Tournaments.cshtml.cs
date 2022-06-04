using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TournamentWebApplication.Pages
{
    public class TournamentsModel : PageModel
    {
        public ITournamentManager itm;
        public TournamentsModel(ITournamentManager tm)
        {
            this.itm = tm;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Tournament t)
        {

            return RedirectToPage("ShowTournament", t);

        }
    }
}
