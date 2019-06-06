using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GamesWorld.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name:")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

    }
}
