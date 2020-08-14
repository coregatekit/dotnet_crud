using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Services {
    public interface IBookService {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(string bookId);
        Task<Book> CreateBookAsync(Book book);
        Task UpdateBookAsync(string bookId, Book book);
        void RemoveBook(string bookId);
    }
    public class BookService : IBookService {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository) {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetBooksAsync() {
            return await _bookRepository.GetBooksAsync();
        }
        public async Task<Book> GetBookAsync(string bookId) {
            return await _bookRepository.GetBookAsync(bookId);
        }
        public async Task<Book> CreateBookAsync(Book book) {
            return await _bookRepository.CreateBookAsync(book);
        }
        public async Task UpdateBookAsync(string bookId, Book book) {
            await _bookRepository.UpdateBookAsync(bookId, book);
        }
        public void RemoveBook(string bookId) {
            _bookRepository.RemoveBook(bookId);
        }
    }

    
}