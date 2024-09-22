using System.ComponentModel.DataAnnotations;

namespace Mvc_Project.Models.ViewModel
{
    public class AuthorAddViewModel
    {

        [Required]
        public string? FirstName { get; set; }  // Yazarın adı
        [Required]
        public string? LastName { get; set; }  // Yazarın soyadı
        [Required(ErrorMessage = "Lütfen Yıl/Ay/Gün formatında bir tarih giriniz.")]
      
        public DateTime DateOfBirth { get; set; }  // Doğum tarihi

        
    }
}
