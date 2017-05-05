using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookCoreAPI.Models;
using BookCoreAPI.Services;

namespace BookCoreAPI {
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;

        public BookController(IBookRepository bookRepo) {
            this._bookRepo = bookRepo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<BookModel> Get()
        {
            return _bookRepo.GetBooks();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult Get(int id)
        {
            BookModel _book = _bookRepo.GetById(id);
            if (_book != null) return Ok(_book);
            else return NotFound();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]BookModel _book)
        {
            if (_book == null) return BadRequest();
            BookModel _newBook = _bookRepo.Add(_book);
            return CreatedAtRoute("GetBook", new { id = _newBook.Id }, _newBook);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BookModel value)
        {
            if (value == null) {
                return BadRequest();
            }
            else {
                var existingBook = _bookRepo.GetById(id);
                if (existingBook == null) return NotFound();
                else {
                    _bookRepo.Update(value);
                    return NoContent();
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingBook = _bookRepo.GetById(id);
            if (existingBook == null) {
                return NotFound();
            }
            else {
                _bookRepo.Delete(existingBook);
                return NoContent();
            }
        }
    }
}