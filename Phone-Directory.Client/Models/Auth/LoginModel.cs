using System.ComponentModel.DataAnnotations;

namespace Models.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girilmesi zorunludur.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre girilmesi zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }
    }
}
