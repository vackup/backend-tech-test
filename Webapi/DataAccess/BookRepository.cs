using DataAccess.Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(BookLibraryDbContext context) : base(context)
        {
        }
    }
}