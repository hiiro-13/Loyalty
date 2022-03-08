using System.ComponentModel.DataAnnotations;

namespace Loyalty.Model
{
    public class Auther
    {
        [Required]
        [Display(Name ="LastName")] 
        public string Username { get; set; }
        [Required]
        [Display(Name ="LastName")] 
        public string Password { get; set; }
    
    }
}