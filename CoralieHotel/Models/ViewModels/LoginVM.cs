﻿using System.ComponentModel.DataAnnotations;

namespace CoralieHotel.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remenber Me")]
        public bool RemenberMe { get; set; }
    }
}
