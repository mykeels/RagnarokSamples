using System.Linq;
using System.Collections.Generic;
using BookCoreAPI.Models;
using BookCoreAPI.Data;

namespace BookCoreAPI.Services {
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly DbAPIContext _context;

        public InMemoryBookRepository(DbAPIContext context)
        {
            _context = context;
        }

        public BookModel Add(BookModel book)
        {
            var addedBook = _context.Add(book);
            _context.SaveChanges();
            book.Id = addedBook.Entity.Id;
            return book;
        }

        public void Delete(BookModel book)
        {
            _context.Remove(book);
            _context.SaveChanges();
        }

        public IEnumerable<BookModel> GetBooks()
        {
            return _context.Books.ToList();
        }

        public BookModel GetById(int id)
        {
            return _context.Books.SingleOrDefault(x => x.Id == id);
        }

        public void Update(BookModel book)
        {
            var bookToUpdate = GetById(book.Id);
            bookToUpdate.Author = book.Author;
            bookToUpdate.Title = book.Title;
            bookToUpdate.PublishedDate = book.PublishedDate;
            _context.Update(bookToUpdate);
            _context.SaveChanges();
        }
    }
}