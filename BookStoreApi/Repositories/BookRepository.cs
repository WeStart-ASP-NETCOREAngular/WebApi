using BookStoreApi.Data;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;
using Mapster;
using BookStoreApi.DTOs;

namespace BookStoreApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbContext _context;

        public BookRepository(BooksDbContext context)
        {
            _context = context;
        }
        public async Task<Book> Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> Delete(int id)
        {

            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return false;
            else
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            return await _context.Books.ProjectToType<BookDto>().ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            //if (book == null)
            //    return false;
            return book;
        }

        public async Task<Book> Update(int id, Book bookChanegs)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return book;
            else
            {
                book.Title = bookChanegs.Title;
                await _context.SaveChangesAsync();
                return book;
            }
        }
    }
}
