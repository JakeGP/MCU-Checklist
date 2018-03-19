using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MCUChecklist.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "Username")]
        public string UserCommonName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string UserEmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public bool AllowNotifications { get; set; }
    }
}