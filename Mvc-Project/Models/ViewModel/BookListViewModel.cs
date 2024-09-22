using System.ComponentModel.DataAnnotations;

namespace Mvc_Project.Models.ViewModel
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int CopiesAvailable { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorFullName { get; set; }

    }
}
