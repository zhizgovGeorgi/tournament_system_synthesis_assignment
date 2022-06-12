using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;

namespace TournamentWebApplication.Pages
{
    public class TournamentWithMatchesModel : PageModel
    {
        ITournamentManager tm;
        IMatchManager mm;
        public TournamentWithMatchesModel(ITournamentManager tm, IMatchManager mm)
        {
            this.tm = tm;
            this.mm = mm;
        }
        public Tournament t;


        public void OnGet(int id)
        {
            t = tm.GetTournament(id);
            mm.GetMatchesForTournament(t);
        }
    }
}
