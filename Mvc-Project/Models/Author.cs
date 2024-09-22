using System.ComponentModel.DataAnnotations;

namespace Mvc_Project.Models
{
    public class Author
    {
        public int Id { get; set; }  // Benzersiz kimlik
        public string FirstName { get; set; }  // Yazarın adı
        public string LastName { get; set; }  // Yazarın soyadı
        
        public DateTime DateOfBirth { get; set; } // Doğum tarihi
        public bool IsDeleted { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
