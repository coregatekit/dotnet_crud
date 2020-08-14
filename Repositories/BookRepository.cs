using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using MongoDB.Driver;

namespace Repositories {
    public interface IBookRepository {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(string bookId);
        Task<Book> CreateBookAsync(Book book);
        Task UpdateBookAsync(string bookId, Book book);
        void RemoveBook(string bookId);
    }
    public class BookRepository : IBookRepository {
        private readonly IMongoCollection<Book> _books;

        public BookRepository(IBooksDBSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BookCollectionName);
        }

        public async Task<List<Book>> GetBooksAsync() =>
            await _books.Find(c => true).ToListAsync();

        public async Task<Book> GetBookAsync(string bookId) =>
            await _books.Find(c => c.Id == bookId).FirstOrDefaultAsync();

        public async Task<Book> CreateBookAsync(Book book) {
            await _books.InsertOneAsync(book);
            return book;
        }

        public async Task UpdateBookAsync(string bookId, Book book) {
            await _books.ReplaceOneAsync(b => b.Id == bookId, book);
        }


        public void RemoveBook(string bookId) {
            _books.DeleteOne(book => book.Id == bookId);
        }
            
    }
}