using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Contracts;
using DataAccess.Contracts;
using Entities;

namespace Business
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository repository;

        public BookBusiness(IBookRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await this.repository.GetAllAsync();
        }

        public async Task<Book> GetAsync(int id)
        {
            return await this.repository.GetAsync(id);
        }

        public async Task<Book> GetFirstOrDefaultAsync()
        {
            return await this.repository.GetFirstOrDefaultAsync();
        }

        public async Task InsertAsync(Book entity)
        {
            await this.repository.InsertAsync(entity);
        }

        public async Task UpdateAsync(Book entity)
        {
            await this.repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await this.repository.DeleteAsync(id);
        }

        public async Task DeleteAsync(Book entity)
        {
            await this.repository.DeleteAsync(entity);
        }
    }
}
