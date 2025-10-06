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
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryContext _context;
        public MemberRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Members newMember)
        {
            _context.Members.Add(newMember);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Members member)
        {
            _context.Members.Remove(member);
            return await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Members>> GetAllAsync()
        {
            return await _context.Members.AsNoTracking().ToListAsync();
        }
        public async Task<Members?> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<Members>(id);
        }
        public async Task<int> Update(Members existingMember)
        {
            _context.Members.Update(existingMember);
            return await _context.SaveChangesAsync();
        }
    }
}
