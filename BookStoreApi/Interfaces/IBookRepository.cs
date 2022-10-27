using BookStoreApi.DTOs;
using BookStoreApi.Models;

namespace BookStoreApi.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookDto>> GetAllBooks();
        Task<Book> GetById(int id);
        Task<Book> Add(Book book);
        Task<Book> Update(int id, Book bookChanegs);
        Task<bool> Delete(int id);


    }
}
