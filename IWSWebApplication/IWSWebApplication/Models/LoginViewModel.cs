using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Ajax;
//More
using System.ComponentModel.DataAnnotations;

namespace IWSWebApplication.Models
{
    public class LoginViewModel
    {
        //Signin Form
        [Required]
        [EmailAddress]
        public string LoginEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }

        //Signup Form
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string RegisterFirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string RegisterLastName { get; set; }
        [Required]
        [EmailAddress]
        public string RegisterEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string RegisterPassword { get; set; }
    }
}
