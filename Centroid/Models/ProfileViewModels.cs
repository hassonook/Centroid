using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Centroid.Models
{
    public class ProfileViewModels
    {
        public string CareerText { get; set; }
        public List<string> CareerMenu { get; set; }
        public IList<Job> Jobs { get; set; }
    }

    public class ProfileRegisterViewModel
    {
        [Required]
        [Display(Name = "Email Address"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ProfileLoginViewModel
    {
        [Required]
        [Display(Name = "Email Address"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}