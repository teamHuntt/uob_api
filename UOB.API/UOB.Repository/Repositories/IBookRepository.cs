
using UOB.Repository.EF.Entities;

namespace UOB.Repository.Repositories
{
    public interface IBookRepository
    {
        Task<int> AddAsync(Book newBook);
        Task<int> Delete(Book book);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(Guid id);
        Task<int> UpdateAsync(Book existingBook);
    }
}