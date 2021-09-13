using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Business.Contracts;
using DataAccess.Contracts;
using Entities;

namespace Business
{
    public class AuthorBusiness : IAuthorBusiness
    {
        private readonly IAuthorRepository repository;

        public AuthorBusiness(IAuthorRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await this.repository.GetAllAsync();
        }

        public async Task<Author> GetAsync(int id)
        {
            return await this.repository.GetAsync(id);
        }

        public async Task<Author> GetFirstOrDefaultAsync()
        {
            return await this.repository.GetFirstOrDefaultAsync();
        }

        public async Task InsertAsync(Author entity)
        {
            await this.repository.InsertAsync(entity);
        }

        public async Task UpdateAsync(Author entity)
        {
            await this.repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await this.repository.DeleteAsync(id);
        }

        public async Task DeleteAsync(Author entity)
        {
            await this.repository.DeleteAsync(entity);
        }
    }
}