using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.DTOs
{
    public class RegisterRequestDto
    {

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
