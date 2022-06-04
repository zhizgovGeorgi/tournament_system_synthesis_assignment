using DAL;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TournamentWebApplication.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Register register { get; set; }

        private readonly IUserManger um;

        public RegisterModel(IUserManger um)
        {
            this.um = um;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                User user = new User(register.FName, register.LName, register.Email, register.Adress, register.Password, "User");

                um.AddUser(user);
                return RedirectToPage("LogIn");

            }
            return Page();
        }
    }
}
