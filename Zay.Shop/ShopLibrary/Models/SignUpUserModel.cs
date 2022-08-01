using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProjectPractise.Models
{
    public class SignUpUserModel
    {
        
        public string Id { get; set; }
        //[Required(ErrorMessage ="Please Enter your First Name")]
        public string FirstName { get; set; }
        public string LastNme { get; set; }

        //[Required(ErrorMessage = "Please Enter Our Email")]
        //[Display(Name = "Email Address")]
        //[EmailAddress(ErrorMessage = "Please Enter a Valid Email")]

        public string Email { get; set; }

        public string Username { get; set; }


        //[Required(ErrorMessage = "Please Enter your Password")]
        //[Compare("ConfirmPassword", ErrorMessage = "Password doesn't match")]
        //[Display(Name = "Password")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Please Enter your Password")]
        //[Display(Name = "Confirm Password")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Image { get; set; }

        public string role { get; set; }
    }
}
