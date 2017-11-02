﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTV.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Registration : IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address: ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        [Display(Name = "Hasło: ")]
        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        
        [Display(Name = "Nazwa użytkownika: ")]
        public string UserName { get; set; }
        [Display(Name = "Funkcja: ")]
        public String Role { get; set; }
    }
}