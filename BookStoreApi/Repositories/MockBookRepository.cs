using BookStoreApi.DTOs;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;

namespace BookStoreApi.Repositories
{
    public class MockBookRepository : IBookRepository
    {
        public static List<Book> _books { get; set; }

        public MockBookRepository()
        {
            _books = new List<Book>() {
                new Book() { Id = 1, Title ="Asp.net core with angular"},
                new Book() { Id = 2, Title ="Web Development"},
            };
        }
        public Task<Book> Add(Book book)
        {
            _books.Add(book);
            return Task.FromResult(book);
        }

        public Task<bool> Delete(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _books.Remove(book);
                return Task.FromResult(true);
            }
            else
                return Task.FromResult(false);

        }

        public Task<List<BookDto>> GetAllBooks()
        {
            return Task.FromResult(_books.Select(x => new BookDto { Title = x.Title }).ToList());
        }

        public Task<Book> GetById(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            //if (book == null)
            //else
            return Task.FromResult(book);
        }

        public Task<Book> Update(int id, Book bookChanegs)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                book.Title = bookChanegs.Title;
                return Task.FromResult(book);
            }
            else
                throw new Exception("Book Not found");
        }
    }
}
