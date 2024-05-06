﻿using System.ComponentModel.DataAnnotations;

namespace CoralieHotel.Models.ViewModels
{
    public class RegisterVM
    {

        [Required]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords dont match")]
        [Display(Name = "Comfirm Password")]
        public string? ConfirmPassword { get; set; }

    }
}
