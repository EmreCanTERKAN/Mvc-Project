using System.ComponentModel.DataAnnotations;

namespace Mvc_Project.Models.ViewModel
{
    public class BookAddViewModel
    {

        public BookAddViewModel()
        {
            PublishDate = DateTime.Now; 
        }

        [Required]
        public string Title { get; set; }  // Kitap başlığı
        [Required]
        public string Genre { get; set; }  // Kitap türü
        [Required]
        public string ISBN { get; set; }  // ISBN numarası
        [Required]
        public int CopiesAvailable { get; set; }  // Mevcut kopya sayısı
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public int AuthorId { get; set; }


    }
}
