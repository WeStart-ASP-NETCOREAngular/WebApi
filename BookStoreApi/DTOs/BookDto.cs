using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.DTOs
{
    public class BookDto
    {
        [Required]
        //[RegularExpression("",ErrorMessage ="لا يمكن ادخال رقم في هذا النص")]
        public string Title { get; set; }




    }
}
