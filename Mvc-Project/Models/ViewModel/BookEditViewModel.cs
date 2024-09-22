using System.ComponentModel.DataAnnotations;

namespace Mvc_Project.Models.ViewModel
{
    public class BookEditViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }  // Kitap başlığı

        public string? Genre { get; set; }  // Kitap türü

        public string? ISBN { get; set; }  // ISBN numarası

        public int CopiesAvailable { get; set; }  // Mevcut kopya sayısı

        public DateTime PublishDate { get; set; }

        public int AuthorId { get; set; }
   
        public string? AuthorFullName { get; set; }
    }
}
