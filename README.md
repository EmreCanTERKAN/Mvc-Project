MVC Projesi
MVC PROJESİ : Kütüphane Yönetim Sistemi

Proje Tanımı:Bu uygulama, bir kütüphanenin kitap, yazar işlemlerini yönetmek için kapsamlı bir sistem olacaktır. Projede birden fazla model ve sayfa içerecektir.

Projeyi kodlarken OOP (Nesne Yönelimli Programlama) prensiplerini kullanıldı.
Proje Gereksinimleri:

    Model Oluşturma:

        Book Modeli:

            Id: (Benzersiz kimlik, int türünde)

            Title: (Kitap başlığı, string türünde)

            AuthorId: (Yazar kimliği, int türünde, Author modeline referans)

            Genre: (Kitap türü, string türünde)

            PublishDate: (Yayın tarihi, DateTime türünde)

            ISBN: (ISBN numarası, string türünde)

            CopiesAvailable: (Mevcut kopya sayısı, int türünde)

        Author Modeli:

            Id: (Benzersiz kimlik, int türünde)

            FirstName: (Yazarın adı, string türünde)

            LastName: (Yazarın soyadı, string türünde)

            DateOfBirth: (Doğum tarihi, DateTime türünde)

        User Modeli:

            Id: (Benzersiz kimlik, int türünde)

            FullName: (Üye adı ve soyadı, string türünde)

            Email: (Üye e-posta adresi, string türünde)

            Password: (Üye giriş parolası, string türünde)

            PhoneNumber: (Üye telefon numarası, string türünde)

            JoinDate: (Üye kayıt tarihi, DateTime türünde)

    ViewModel Oluşturma:

        Kitap detaylarını ve ilgili bilgileri gösterecek bir ViewModel oluşturun. Bu ViewModel kitapların listeleneceği sayfalar için de kullanılabilir.

        Yazar detaylarını ve yazarların listeleneceği sayfalar için kullanılacak bir ViewModel oluşturun.

        Kayıt olma ve giriş yapma sayfaları için kullanılacak birer ViewModel oluşturun.

    Controller Oluşturma:

        BookController: Kitaplarla ilgili işlemleri yönetecek ve aşağıdaki aksiyon metodlarına sahip olacak:

            List: Kitapların listesini gösterir.

            Details: Belirli bir kitabın detaylarını gösterir.

            Create: Yeni bir kitap eklemek için form sağlar.

            Edit: Var olan bir kitabı düzenlemek için form sağlar.

            Delete: Kitabı silmek için bir onay sayfası sağlar.

        AuthorController: Yazarlarla ilgili işlemleri yönetecek ve aşağıdaki aksiyon metodlarına sahip olacak:

            List: Yazarların listesini gösterir.

            Details: Belirli bir yazarın detaylarını gösterir.

            Create: Yeni bir yazar eklemek için form sağlar.

            Edit: Var olan bir yazarı düzenlemek için form sağlar.

            Delete: Yazarı silmek için bir onay sayfası sağlar.

        AuthController: Üyelerle ilgili işlemleri yönetecek ve aşağıdaki aksiyon metodlarına sahip olacak:

            SignUp: Kayıt işlemini yönetir.

            Login: Giriş işlemini yönetir.

    View Oluşturma:

        Book Views:

            List: Kitapların listesini görüntüleyen bir view.  Bir buton ile silme işlemi de yapılır.

            Details: Kitap detaylarını görüntüleyen bir view.

            Create: Yeni kitap eklemek için form içeren bir view.

            Edit: Var olan kitapları düzenlemek için form içeren bir view.

        Author Views:

            List: Yazarların listesini görüntüleyen bir view. Bir buton ile silme işlemi de yapılır.

            Details: Yazar detaylarını görüntüleyen bir view.

            Create: Yeni yazar eklemek için form içeren bir view.

            Edit: Var olan yazarları düzenlemek için form içeren bir view.

        User Views:

            Sign Up: User bilgileriyle kayıt olunan bir view. Mutlaka Şifre Tekrarı alanı içermeli ve şifreyle aynı olmadığında uyarı verilmeli.

            Login:  Email ve Şifre ile giriş yapılan bir view. İşlem sonucu ya aynı sayfada hata verilmeli ya da giriş yapıldığı için ana sayfaya yönlendirilmeli.

    Program.cs Konfigürasyonu:

        MVC Servislerinin Eklenmesi: MVC yapılandırmalarını gerçekleştirin.

        wwwroot Kullanımı: wwwroot klasöründeki statik dosyaların kullanılmasını sağlayın.

        Routing Konfigürasyonu: İsteklerin doğru controller ve aksiyon metodlarına yönlendirilmesini sağlayın.

        Varsayılan Routing: Anasayfa için varsayılan bir routing yapılandırması ekleyin.

NOTLAR:

Projenizde Layout - PartialView kullanınız.

Projenizde sayfanın altına sabitlenmiş, hakların size ait olduğuna dair bir yazı içeren bir footer bulunsun.

Projenizde bulunması gereken sayfalar : Ana Sayfa - Hakkında 
