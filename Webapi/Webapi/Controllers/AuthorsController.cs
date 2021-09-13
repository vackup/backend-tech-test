using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Contracts;
using Entities;
using Webapi.Models;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorBusiness business;

        public AuthorsController(IAuthorBusiness business)
        {
            this.business = business ?? throw new ArgumentNullException(nameof(business));
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            return await this.business.GetAllAsync();
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            return await this.business.GetAsync(id);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public async Task Post([FromBody] AuthorCreationModel authorCreationModel)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }

            var author = new Author()
            {
                Id = authorCreationModel.Id,
                Name = authorCreationModel.Name
            };

            await this.business.InsertAsync(author);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }

            author.Id = id;

            await this.business.UpdateAsync(author);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.business.DeleteAsync(id);
        }
    }
}
