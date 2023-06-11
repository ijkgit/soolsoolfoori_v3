using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TermProject_2018136107.Models
{
    public class LoginInfo
    {

        [Required(ErrorMessage = "Enter your ID")]
        [MinLength(5, ErrorMessage = "Enter at least 5 characters")]
        [Display(Name = "ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Enter your Password")]
        [MinLength(6, ErrorMessage = "Enter at least 5 characters")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
