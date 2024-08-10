using System.ComponentModel.DataAnnotations;

namespace Models.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girilmesi zorunludur.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ad girilmesi zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad girilmesi zorunludur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Şifre girilmesi zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre tekrarının girilmesi zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [Compare("Password", ErrorMessage = "Şifre ve Şifre Tekrarı için girilenler aynı olmalıdır.")]
        public string ConfirmPassword { get; set; }
    }
}
