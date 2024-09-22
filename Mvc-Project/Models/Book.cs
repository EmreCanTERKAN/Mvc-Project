using System.ComponentModel.DataAnnotations;

namespace Mvc_Project.Models
{
    public class Book
    {
        public Book()
        {
            PublishDate = DateTime.Now;
        }
        public int Id { get; set; }  // Benzersiz kimlik
        [Required]
        public string? Title { get; set; }  // Kitap başlığı
        [Required]
        public int AuthorId { get; set; }  // Author modeline referans (Foreign Key)
        [Required]
        public string? Genre { get; set; }  // Kitap türü
        [Required]
        public DateTime PublishDate { get; set; }  // Yayın tarihi
        [Required]
        public string? ISBN { get; set; }  // ISBN numarası
        [Required]
        public int CopiesAvailable { get; set; }  // Mevcut kopya sayısı

        public bool IsDeleted { get; set; }
        //public string? AuthorFullName { get; set; }
    }
}
