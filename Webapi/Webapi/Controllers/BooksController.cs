using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Contracts;
using Entities;
using Webapi.DTOs;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookBusiness business;

        public BooksController(IBookBusiness business)
        {
            this.business = business ?? throw new ArgumentNullException(nameof(business));
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await this.business.GetAllAsync();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await this.business.GetAsync(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task Post([FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }

            await this.business.InsertAsync(GetEntity(book));
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }

            book.Id = id;

            await this.business.UpdateAsync(GetEntity(book));
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.business.DeleteAsync(id);
        }

        private Book GetEntity(BookDTO book)
        {
            return new Book
            {
                Id = book.Id,
                Author = new Author { Id = book.AuthorId },
                Title = book.Title
            };
        }
    }
}
