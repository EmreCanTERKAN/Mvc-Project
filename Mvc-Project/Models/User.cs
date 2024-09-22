namespace Mvc_Project.Models
{
    public class User
    {

        public User()
        {
            JoinDate = DateTime.Now;
        }
        public int Id { get; set; }  // Benzersiz kimlik
        public string FirstName { get; set; }  // Üye adı 
        public string LastName { get; set; } // Üye Soyadı
        public string Email { get; set; }  // Üye e-posta adresi
        public string Password { get; set; }  // Üye giriş parolası
        public string PhoneNumber { get; set; }  // Üye telefon numarası
        public DateTime JoinDate { get; set; }  // Üye kayıt tarihi

        public string FullName => $"{FirstName} {LastName}";
    }
}
