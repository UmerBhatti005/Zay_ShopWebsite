using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProjectPractise.Models
{
    public class ChangePasswordModel
    {

        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword", ErrorMessage = "Password Doesn't Match")]
        public string ConfirmNewPassword { get; set; }
    }
}
