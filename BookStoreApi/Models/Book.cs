using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Models
{
    //[Table("tb_Book")]
    public class Book
    {
        //[Column(Order = 1)]
        public int Id { get; set; }
        [Required]
        //[Column(Order = 3)]
        public string Title { get; set; } = string.Empty;

        //[Column(Order = 2)]
        //public string Description { get; set; }

    }
}
