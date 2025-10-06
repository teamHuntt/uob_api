using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOB.Repository.EF.Context;
using UOB.Repository.EF.Entities;

namespace UOB.Repository.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Book newBook)
        {
            _context.Books.Add(newBook);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Book book)
        {
            _context.Books.Remove(book);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<int> UpdateAsync(Book existingBook)
        {
            _context.Books.Update(existingBook);
            return await _context.SaveChangesAsync();
        }
    }
}
