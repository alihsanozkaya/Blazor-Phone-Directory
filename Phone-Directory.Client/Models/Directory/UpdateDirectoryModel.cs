using System.ComponentModel.DataAnnotations;

namespace Models.Directory
{
    public class UpdateDirectoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Telefon alanı gereklidir.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int UserId { get; set; }
    }
}
