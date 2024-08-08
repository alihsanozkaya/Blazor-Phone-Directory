using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Entities.DTOS.User
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Girilmesi Zorunludur")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre Girilmesi Zorunludur")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ad Girilmesi Zorunludur")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad Girilmesi Zorunludur")]
        public string LastName { get; set; }
    }
}
