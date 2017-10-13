using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Added
using System.ComponentModel.DataAnnotations;

namespace IWSWebApplication.Models
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(30,MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
