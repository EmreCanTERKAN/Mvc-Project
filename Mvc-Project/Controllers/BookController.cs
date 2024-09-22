using Microsoft.AspNetCore.Mvc;
using Mvc_Project.Models;
using Mvc_Project.Models.ViewModel;

namespace Mvc_Project.Controllers
{
    public class BookController : Controller
    {
        // Veri tabanı olmadığı için bir liste tanımladık...
        public static List<Book> _books = new List<Book>()
        {
            new Book () {Id = 1 , Title ="Deneme", Genre = "Fizik", ISBN="234324", CopiesAvailable=4324, AuthorId=2 },
            new Book () {Id = 2 , Title ="Deneme1", Genre = "Tarih", ISBN="23", CopiesAvailable=12, AuthorId=1 },
        };
        // IsDeleted'ı false olan bütün elemanları getirip bunu Book List View Modele ekleyip listeliyoruz..
        public IActionResult List()
        {

            var yazarlar = AuthorController._authors;
            var books = _books.Where(x => x.IsDeleted == false).Select(x => new BookListViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Genre = x.Genre,
                PublishDate = x.PublishDate,
                CopiesAvailable = x.CopiesAvailable,
                AuthorId = x.AuthorId,
                AuthorFullName = yazarlar.FirstOrDefault(y=> y.Id == x.AuthorId)?.FullName // burada Auth listesindeki elemanların içinden idsi booktaski author idye eşit olanın Full name'ını yazarın full name'ine atadık
                
                       
            }).ToList();
            return View(books);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var yazarlar = AuthorController._authors;
            ViewBag.Author = yazarlar; // add view'de select'e bilgi göndermek için burada auth listesindeki yazarları bir değişkene atayıp view bag ile taşıdık.
            return View();
        }
        // Ekleme İşlemi Yapıyoruz...
        [HttpPost]
        public IActionResult Add(BookAddViewModel viewModel)
        {
            var yazarlar = AuthorController._authors;
            // ModelState Dolu değilse view'e gönder
            if (!ModelState.IsValid)
            {
                ViewBag.Author = yazarlar;
                return View(viewModel);
            }   
            
            
            // _book listesinden Maximum idyi bulup bunu maxId değişkenine atadık.
            int maxId = _books.Max(x => x.Id);
            //Viewden aldığımız bilgileri yeni kitap listesine ekliyoruz.
            var newBook = new Book()
            { 
                Id = maxId + 1,
                Title = viewModel.Title,
                Genre = viewModel.Genre,
                ISBN = viewModel.ISBN,
                CopiesAvailable = viewModel.CopiesAvailable,
                AuthorId = viewModel.AuthorId,
                //AuthorFullName = yazarlar.FirstOrDefault(x => x.Id == viewModel.AuthorId)?.FullName
            };
            _books.Add(newBook);
            // En son işlem olarak bizi Book controllerındaki List actionuna yönlendiriyor.
            return RedirectToAction("List", "Book");
        }

        // Burada soft delete bir silme yaptık..
        public IActionResult Delete(int id)
        {
            var book = _books.Find(x => x.Id == id);
            book.IsDeleted = true;
            return RedirectToAction("List", "Book");
        }
        // Detayları Gösteren action.

        public IActionResult Details(int id)
        {
            
            var book = _books.Find(b => b.Id == id);
            var newBook = new BookDetailViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable,
                AuthorId = book.AuthorId,
                

            };
            if (book == null)
            {
                return NotFound();
            }
            return View(newBook);

        }
        // idsi ile eşitlenen kitabı bulur ardından yeni bir viewmodel ile listedeki eşleşen kitabın propertileri viewmodele aktarılır.

        [HttpGet] 
        public IActionResult Edit(int id)
        {
            var yazarlar = AuthorController._authors;
            ViewBag.Author = yazarlar;
            var book = _books.Find(b => b.Id == id);
            var viewModel = new BookEditViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable,
                AuthorId = book.AuthorId

            };
            return View(viewModel);

        }
        // get metoduyla bilgiler forma geldikten sonra yapılması gerene değişiklikler yapılır ve tekrardan list actionuna gidilir. 

        [HttpPost]
        public IActionResult Edit(BookEditViewModel formData)
        {
            var yazarlar = AuthorController._authors;
            ViewBag.Author = yazarlar;
            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            var book = _books.Find(x => x.Id == formData.Id);
            book.Title = formData.Title;
            book.Genre = formData.Genre;
            book.ISBN = formData.ISBN;
            book.CopiesAvailable = formData.CopiesAvailable;
            book.AuthorId = formData.AuthorId;
            return RedirectToAction("List");

           
        }







    }



}

