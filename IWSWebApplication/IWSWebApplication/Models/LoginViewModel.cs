using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc.Ajax;

//Added
using System.ComponentModel.DataAnnotations;

namespace IWSWebApplication.Models
{
    public class LoginViewModel
    {
        //Login Form
        [Required]
        [EmailAddress]
        public string LoginEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }

        //Register Form
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

    public class RootObject
    {
        public List<LoginViewModel> Loggers { get; set; }
    }
}
