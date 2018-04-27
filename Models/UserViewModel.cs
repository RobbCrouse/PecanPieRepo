using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pecanpie.Models
{
    public class UserViewModel : BaseEntity
    {
        
        [Required( ErrorMessage = "First Name is required.")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required( ErrorMessage = "Last Name is required.")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Display(Name = "Email:")]
        [Required( ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required( ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "Password must contain at least 1 number, 1 letter, and 1 special character.")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "Password must contain at least 1 number, 1 letter, and 1 special character.")]
        [Display(Name = "Confirm Password:")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }


    }
}