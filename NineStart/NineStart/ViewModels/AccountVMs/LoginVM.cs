using System.ComponentModel.DataAnnotations;

namespace NineStart.ViewModels
{
    public class LoginVM
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
