using BookStoreApi.Data;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //private static List<Book> books = new List<Book>()
        //{
        //    new Book { Id = 1, Title = "C# Basics", Author = "John", Price = 500, Stock = 10 },
        //    new Book { Id = 2, Title = "ASP.NET Guide", Author = "Smith", Price = 700, Stock = 5 },
        //    new Book { Id = 3, Title = "Clean Code", Author = "Robert Martin", Price = 1200, Stock = 8 },
        //    new Book { Id = 4, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Price = 1500, Stock = 6 },
        //    new Book { Id = 5, Title = "Design Patterns", Author = "Erich Gamma", Price = 1800, Stock = 4 },
        //    new Book { Id = 6, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", Price = 2000, Stock = 3 },
        //    new Book { Id = 7, Title = "Head First C#", Author = "Andrew Stellman", Price = 900, Stock = 7 }
        //};

        //// GET: api/books
        //[HttpGet]
        //public ActionResult<List<Book>> GetAllBooks()
        //{
        //    if (books.Count == 0)
        //        return NotFound();

        //    return books;
        //}

        //// GET: api/books/1
        //[HttpGet("{id}")]
        //public ActionResult<Book> GetBookById(int id)
        //{
        //    var book = books.FirstOrDefault(b => b.Id == id);

        //    if (book == null)
        //        return NotFound();

        //    return book;
        //}

        //// POST: api/books
        //[HttpPost]
        //public ActionResult<Book> AddBook(Book newBook)
        //{
        //    // Generate ID
        //    newBook.Id = books.Max(b => b.Id) + 1;

        //    books.Add(newBook);

        //    return CreatedAtAction(
        //        nameof(GetBookById),
        //        new { id = newBook.Id },
        //        newBook);
        //}

        //// PUT: api/books/1
        //[HttpPut("{id}")]
        //public IActionResult UpdateBook(int id, Book updateBook)
        //{
        //    var book = books.FirstOrDefault(b => b.Id == id);

        //    if (book == null)
        //        return NotFound();

        //    book.Title = updateBook.Title;
        //    book.Author = updateBook.Author;
        //    book.Price = updateBook.Price;
        //    book.Stock = updateBook.Stock;

        //    return NoContent();
        //}

        //// DELETE: api/books/1
        //[HttpDelete("{id}")]
        //public IActionResult DeleteBook(int id)
        //{
        //    var book = books.FirstOrDefault(b => b.Id == id);

        //    if (book == null)
        //        return NotFound();

        //    books.Remove(book);

        //    return NoContent();
        //}

        private readonly BookStoreApiContext _context;
        public BooksController(BookStoreApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            try
            {
                //var data = _context.Books.Where(x => x.Id != 0 || x.Id != null).ToListAsync();
                var books = await _context.Books.ToListAsync();

                if (books == null || books.Count == 0)
                {
                    return NotFound("No books found.");
                }

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book newBook)
        {
            try
            {
                if (newBook == null)
                {
                    return BadRequest("Invalid book data.");
                }

                newBook.Id = 0;

                await _context.Books.AddAsync(newBook);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBookById),
                    new { id = newBook.Id }, newBook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, Book updatedBook)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                if (id != updatedBook.Id)
                {
                    return BadRequest("ID mismatch.");
                }

                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Price = updatedBook.Price;
                book.Stock = updatedBook.Stock;

                await _context.SaveChangesAsync();

                return Ok("Book updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return Ok("Book deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

