using System;
using System.ComponentModel.DataAnnotations;

namespace Loyalty.Model
{
    public class Role
    {
        [Display(Name ="Id")] 
        public Guid Id { get; set; }
        
        [Display(Name ="Name")] 
        public string Name { get; set; }
        
        [Display(Name ="Description")] 
        public string Description { get; set; }

    }
}