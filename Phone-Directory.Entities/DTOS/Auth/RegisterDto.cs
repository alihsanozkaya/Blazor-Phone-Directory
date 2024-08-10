using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Entities.DTOS.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Kullanıcı adı girilmesi zorunludur.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre girilmesi zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ad girilmesi zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad girilmesi zorunludur.")]
        public string LastName { get; set; }
    }
}
