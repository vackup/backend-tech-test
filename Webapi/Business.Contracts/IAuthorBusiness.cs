using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Business.Contracts
{
    public interface IAuthorBusiness
    {
        Task<IEnumerable<Author>> GetAllAsync();

        Task<Author> GetAsync(int id);

        Task<Author> GetFirstOrDefaultAsync();

        Task InsertAsync(Author entity);

        Task UpdateAsync(Author entity);

        Task DeleteAsync(int id);

        Task DeleteAsync(Author entity);
    }
}