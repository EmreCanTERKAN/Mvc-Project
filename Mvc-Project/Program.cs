using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


//bir mvc projesi olduðunu tanýmladýk
builder.Services.AddControllersWithViews();

//bir authentication eklemesi yapmamýz gerekmektedir.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    //kullanýcý login yaptýðýnda gideceði yol / 
    options.LoginPath = new PathString("/"); //<== burasý anasayfadýr.
    // Logout yaptýðýnda yönlendireceði yol
    options.LogoutPath = new PathString("/"); // <== burasý anasayfadýr.
    // Giriþ reddedildiðinde gideceði yol 
    options.AccessDeniedPath = new PathString("/"); // <== burasý anasayfadýr.
});



var app = builder.Build();


// Statik dosyalarýn kullanýlmasý için 
app.UseStaticFiles();

// kimlik doðrulamayý iþlemlerini yönetmek için tanýmladýðýmýz bir middlewaredir.
// bu authorization middlewareinden önce gelmelidir. Çünkü eriþim izni kimlik dogrulamadan sonra gelmektedir.
app.UseAuthentication();

//default bir rota belirleniyor patterni controller/actin/id? þeklinde olacak.

app.MapDefaultControllerRoute();

app.Run();
