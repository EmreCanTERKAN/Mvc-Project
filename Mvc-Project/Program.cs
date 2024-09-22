using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


//bir mvc projesi oldu�unu tan�mlad�k
builder.Services.AddControllersWithViews();

//bir authentication eklemesi yapmam�z gerekmektedir.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    //kullan�c� login yapt���nda gidece�i yol / 
    options.LoginPath = new PathString("/"); //<== buras� anasayfad�r.
    // Logout yapt���nda y�nlendirece�i yol
    options.LogoutPath = new PathString("/"); // <== buras� anasayfad�r.
    // Giri� reddedildi�inde gidece�i yol 
    options.AccessDeniedPath = new PathString("/"); // <== buras� anasayfad�r.
});



var app = builder.Build();


// Statik dosyalar�n kullan�lmas� i�in 
app.UseStaticFiles();

// kimlik do�rulamay� i�lemlerini y�netmek i�in tan�mlad���m�z bir middlewaredir.
// bu authorization middlewareinden �nce gelmelidir. ��nk� eri�im izni kimlik dogrulamadan sonra gelmektedir.
app.UseAuthentication();

//default bir rota belirleniyor patterni controller/actin/id? �eklinde olacak.

app.MapDefaultControllerRoute();

app.Run();
