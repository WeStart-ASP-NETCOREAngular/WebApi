using BookStoreApi.DTOs;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    // Specific Type
    // IActionResult
    // ActionResult
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookRepository.GetAllBooks());
        }

        /// <summary>
        /// Get a book with auther details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Returns a book</response>
        /// <response code="404">Book not found in our database</response>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _bookRepository.GetById(id);
            //return book;
            if (book == null)
                return NotFound();
            else
                return Ok(book);
        }

        /// <summary>
        /// Adds New Book 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="book"> Book </param>
        /// <returns></returns>
        /// <response code="200">Successfully Added newly Book</response>
        [HttpPost("addpost")]
        [Consumes("application/json")]

        //[ProducesResponseType(statusCode: 200, type:typeof(Book))]
        public async Task<IActionResult> Post([FromBody] BookDto book)
        {
            var bookResult = await _bookRepository.Add(new Book { Title = book.Title });
            return Ok(bookResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            var result = await _bookRepository.Update(id, book);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookRepository.Delete(id);
            if (result == true)
                return Ok("Book has been Deleted");
            else
                return BadRequest();
        }
    }
}
