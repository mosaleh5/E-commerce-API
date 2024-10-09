﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.UserService.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+={}\[\]:;""'<>,.?/~`-]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]

        public string  Password { get; set; }

    }
}
