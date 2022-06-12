using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TournamentWebApplication.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly IMatchManager mManager;
        private readonly ITournamentManager tManager;
        public ResultsModel(IMatchManager mm, ITournamentManager tm)
        {
            this.tManager = tm;
            this.mManager = mm;
        }
        public void OnGet()
        {
        }
    }
}
