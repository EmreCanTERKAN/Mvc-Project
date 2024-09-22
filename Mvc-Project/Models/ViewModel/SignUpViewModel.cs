using System.ComponentModel.DataAnnotations;

namespace Mvc_Project.Models.ViewModel
{
    public class SignUpViewModel
    {
        [Required]
        public string FirstName { get; set; }  // Üye adı 
        [Required]
        public string LastName { get; set; } // Üye Soyadı
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }
        [Required]
        public string PhoneNumber { get; set; }  // Üye telefon numarası

    }
}
