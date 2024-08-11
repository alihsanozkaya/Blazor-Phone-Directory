using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.Entities.DTOS.User
{
    public class UpdateUserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı girilmesi zorunludur.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ad girilmesi zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad girilmesi zorunludur.")]
        public string LastName { get; set; }
    }
}
