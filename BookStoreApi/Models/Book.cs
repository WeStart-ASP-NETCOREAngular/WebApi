using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

    }
}
