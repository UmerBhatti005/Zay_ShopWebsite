using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProjectPractise.Models
{
    public class SignInUserModel
    {
        public int Id { get; set; }
        //[Required, EmailAddress]
        //[Display(Name ="Email Address")]

        //[Column(TypeName ="varchar(50)")]
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Our Password")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool Rememberme { get; set; }
    }
}
