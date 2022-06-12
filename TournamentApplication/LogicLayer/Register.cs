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
        [Required(ErrorMessage = "Please enter a first name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please enter your email")][RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Must be a valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter an adress")]
        public string Adress { get; set; }


        [Required(ErrorMessage = "Please enter password")][MinLength(6, ErrorMessage ="Password should contain at least 6 characters!")]
        public string Password { get; set; }
    }
}
