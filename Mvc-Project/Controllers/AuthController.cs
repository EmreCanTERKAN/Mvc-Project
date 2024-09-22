using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Mvc_Project.Models;
using Mvc_Project.Models.ViewModel;
using System.Security.Claims;

namespace Mvc_Project.Controllers
{
    public class AuthController : Controller
    {

        private static List<User> _users = new List<User>()
        {
            new User(){Id = 1 , Email = ".", FirstName="Emre",LastName="TERKAN", Password = ".",JoinDate=DateTime.Now, PhoneNumber="123"},
            new User(){Id = 2 , Email = "deneme@patika.dev",FirstName ="deneme" ,LastName="deneme", Password = "123",JoinDate=DateTime.Now, PhoneNumber="123"}
        };
        // Sadece constructorda  tanımlanabilen readonly bir değişken tanımladık
        private readonly IDataProtector _dataProtector;

        // bir class içerisindeki metotları başka bir class içerisinde kullanmak istersem 
        // burada kendi değişkenimle oluşturduğumuz robotu bağlıyoruz.
        public AuthController(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpViewModel formData)
        {
            // model state boş ise aşağıdaki şart
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            // aşağıda eğer ki kullanıcı post ettiği email ile listedeki bir elemanın emaili ile eşleşir ise kullanıcı mevcut hatası dönecektir.
            var user = _users.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());

            if (user is not null)
            {
                ViewBag.Error = "Kullanıcı Mevcut";
                return View(formData);
            }
            //Yeni bir User tanımladık
            var newUser = new User()
            {
                //user listesindeki maximum değerin 1 fazlasını Id ye atıyoruz
                Id = _users.Max(x => x.Id) + 1,
                FirstName = formData.FirstName,
                LastName = formData.LastName,
                Email = formData.Email,
                // buradaki işlem yani yukarıda tanımladığımız metot formdan gelen şifreyi kriptolu şekilde kayıt ediyor..
                Password = _dataProtector.Protect(formData.Password),
                JoinDate = DateTime.Now,
                PhoneNumber = formData.PhoneNumber
            };
            // Tanımlanan user'i Listeye ekledik
            _users.Add(newUser);
            // ardından redirect ile ana sayfaya yönlendirdik.
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel formData)
        {
            //Validasyon hatası döndürmesi için öncelikle bir şart tanımladım.
            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            // formdatadaki email ile userdeki emaili eşleşen ilk değeri getirme metodu FirstOrDefault
            var user = _users.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());
          

            // eğer yukarıdaki sorguda emailler eşit değilse hata mesajı döndürecektir
            if (user is null)
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                return View(formData);
            }


            // kayıt ederken kriptopulu kayıt etmiştik. Şimdi kullanıcı şifreyi kontrol ederken önce email ile eşleşen user'in şifresinin kriptoposunu iptal edip kontrol etmeliyiz.
            // userin passwordunu unprotect edip rawPassword değişkenine atadık..
            var rawPassword = _dataProtector.Unprotect(user.Password);



            // eğer formdan gelen password ile listedeki unprotec ettiğimiz password eşitlenirse kayıt işlemi yapılmalıdır..
            if (rawPassword == formData.Password)
            {
                // kayıt işleminin ilk işi claim türünden bir dosya açılık içindekileri buna kayıt etmek.
                var claims = new List<Claim>();
                claims.Add(new Claim("email", user.Email));
                // id numerik bir değer olduğu için biz bunu stringe çevirmemiz gerekiyor..
                claims.Add(new Claim("id", user.Id.ToString()));
                // Artık Bu email ile idye bir kimlik tanımlaması yapılmalıdır.



                // Yukarıdaki liste ile oturum açılacağı için claims'i tanımladık.
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);



                // Daha sonra bu girişin nasıl bir giriş olacağının özelliklerini tanımlıyoruz.
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true, // yenilebilir oturum
                    ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(1)) // oturum açıldıktan sonra 1 saat geçerli.
                };

                // kullanıcı giriş yaptığında bir asenkron işlem yapar, çünkü internet ve bilgisayar hızı gibi faktörler olduğu için sırayla işlem yapar.
                // AWAIT => eş zamanlı yapılan işlemlerin birbirlerini beklemesi için kullanılır. Bu kullanıldığı zaman ilgili metot Task < > olmalıdır. 
                //Asekron metotlar geriye promise döner .

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);
            }
            // eğer şartlar uymuyorsa geriye kullanıcı adı veya şifre hatalı mesajı döndür.
            else
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                return View(formData);
            }
            return RedirectToAction("Index", "Home");


        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
