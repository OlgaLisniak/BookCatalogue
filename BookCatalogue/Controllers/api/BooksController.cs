using BookCatalogue.DAL;
using BookCatalogue.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace BookCatalogue.Controllers.api
{
    public class BooksController : ApiController
    {
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetAllBooks()
        {
            IList<Book> books = null;

            using (var db = new BookContext())
            {
                books = db.Books.ToList();
            }

            if(books.Count == 0)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBookById(int id)
        {
            Book book = null;

            using (var db = new BookContext())
            {
                book = db.Books.Where(b => b.Id == id).FirstOrDefault();
            }

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBookByGenre(string genre)
        {
            IEnumerable<Book> books = null;

            using (var db = new BookContext())
            {
                books = db.Books.Where(b => b.Genre.ToString() == genre).ToList();
            }

            if (books.Count() == 0)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult PostNewBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var db = new BookContext())
            {
                db.Books.Add(new Book()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Year = book.Year,
                    PublishingHouse = book.PublishingHouse
                });

                db.SaveChanges();
            }

            return Ok();
        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult PutBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var db = new BookContext())
            {
                var existingBook = db.Books.Where(b => b.Id == book.Id)
                                                        .FirstOrDefault();

                if (existingBook != null)
                {
                    existingBook.Name = book.Name;
                    existingBook.Author = book.Author;
                    existingBook.Year = book.Year;
                    existingBook.PublishingHouse = book.PublishingHouse;
                    existingBook.Genre = book.Genre;

                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid book id");
            }

            using (var db = new BookContext())
            {
                var book = db.Books.Find(id);

                if (book == null)
                {
                    return NotFound();
                }

                db.Books.Remove(book);
                db.SaveChanges();
            }

            return Ok();
        }
    }
}