using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Register
    {
        [Required(ErrorMessage = "Please enter a Name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Adress { get; set; }


        [Required(ErrorMessage = "Please enter a Name")]
        public string Password { get; set; }
    }
}
