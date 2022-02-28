using System.ComponentModel.DataAnnotations;

namespace Loyalty.Model
{
    public class User
    {
        [EmailAddress]
        [Required]
        [Display(Name ="Email")]

        public string Email { get; set; }
        [Required]
        [Display(Name ="Username")]
        public string Username { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name ="LastName")] 
        public string LastName { get; set; }
        [Required]
        [Display(Name ="FirstName")]
        public string FirstName { get; set; }
        [Display(Name ="RoleName")]
        public string RoleName { get; set; }

    }
}