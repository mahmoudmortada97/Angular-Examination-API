using System.ComponentModel.DataAnnotations;

namespace ExaminationAuthentication.DTO
{
    public class LoginDTO
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
