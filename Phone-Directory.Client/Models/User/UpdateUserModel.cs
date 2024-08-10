using System.ComponentModel.DataAnnotations;

namespace Models.User
{
    public class UpdateUserModel
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
