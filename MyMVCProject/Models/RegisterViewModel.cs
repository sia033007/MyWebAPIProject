using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCProject.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="ConfirmPassword and Password values must be the same")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name ="City (optional)")]
        public string City { get; set; }
        [Display(Name = "Profession (optional)")]
        public string Profession { get; set; }
        [Display(Name = "First Name (optional)")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name (optional)")]
        public string LastName { get; set; }
    }
}
