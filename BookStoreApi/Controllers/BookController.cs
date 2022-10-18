using BookStoreApi.DTOs;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/books")]
    [ApiController]
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _bookRepository.GetById(id);
            if (book == null)
                return NotFound();
            else
                return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BookDto book)
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
