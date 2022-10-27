using BookStoreApi.DTOs;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

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
        private readonly IStringLocalizer<BookController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public BookController(IBookRepository bookRepository,
            IStringLocalizer<BookController> stringLocalizer,
            IStringLocalizer<SharedResource> _sharedLocalizer)
        {
            _bookRepository = bookRepository;
            _stringLocalizer = stringLocalizer;
            this._sharedLocalizer = _sharedLocalizer;
        }

        [HttpGet]
        //[Authorize]
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
        [HttpGet("{id:int}", Name = "GetBookById")]
        [Produces("application/json")]
        //[Route(Name ="")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var title = _stringLocalizer["Title", "Omran", "Best fullstack developer ever"];
            var sharedTitle = _sharedLocalizer["SharedTitle"];

            var book = await _bookRepository.GetById(id);
            //return book;
            if (book == null)
                return NotFound();
            else
                return Ok(new { book = book, title = title, sharedTitle = sharedTitle });
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
        /// <response code="201">Successfully Added newly Book</response>
        [HttpPost("addpost")]
        [Consumes("application/json")]
        //[ProducesResponseType(statusCode: 200, type:typeof(Book))]
        public async Task<IActionResult> Post([FromBody] BookDto book)
        {
            var bookResult = await _bookRepository.Add(new Book { Title = book.Title });
            //return Ok(bookResult);
            //return CreatedAtRoute("GetBookById", new { id = bookResult.Id }, bookResult);
            return CreatedAtAction(nameof(Get), new { id = bookResult.Id }, bookResult);
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
