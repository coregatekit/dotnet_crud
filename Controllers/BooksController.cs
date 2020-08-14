using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksAsync() {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookAsync(string bookId) {
            var book = await _bookService.GetBookAsync(bookId);

            if (book == null) {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync(Book book) {
            var content = await _bookService.CreateBookAsync(book);

            if (content == null) {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBookAsync(string bookId, Book book) {
            await _bookService.UpdateBookAsync(bookId, book);
            return Ok();
        }

        [HttpDelete("{bookId}")]
        public IActionResult RemoveBook(string bookId) {
            _bookService.RemoveBook(bookId);
            return NoContent();
        }
    }
}