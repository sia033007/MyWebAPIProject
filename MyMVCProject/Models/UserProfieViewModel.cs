using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCProject.Models
{
    public class UserProfieViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name ="Your user name")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="Your email address")]
        public string Email { get; set; }
        [Display(Name = "Your city")]
        public string City { get; set; }
        [Display(Name = "Your profession")]
        public string Profession { get; set; }
        [Display(Name = "Your first name")]
        public string FirstName { get; set; }
        [Display(Name = "Your last name")]
        public string LastName { get; set; }
    }
}
