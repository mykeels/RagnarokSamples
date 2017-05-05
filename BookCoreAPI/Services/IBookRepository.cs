using BookCoreAPI.Models;
using System.Collections.Generic;
namespace BookCoreAPI.Services {
    public interface IBookRepository {
        BookModel Add(BookModel book);
        BookModel GetById(int id);
        IEnumerable<BookModel> GetBooks();
        void Delete(BookModel book);
        void Update(BookModel book);
    }
}