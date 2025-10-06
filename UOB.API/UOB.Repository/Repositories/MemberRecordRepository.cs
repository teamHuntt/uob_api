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
    public class MemberRecordRepository : IMemberRecordRepository
    {
        private readonly LibraryContext _context;
        public MemberRecordRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(MemberRecord record)
        {
            _context.MemberRecords.Add(record);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<MemberRecord>> GetAllAsync()
        {
            return await _context.MemberRecords
                 .Include(x => x.Book)
                 .Include(x => x.Member).AsNoTracking().ToListAsync();
        }

        public async Task<int> UpdateAsync(MemberRecord record)
        {
            _context.MemberRecords.Update(record);
            return await _context.SaveChangesAsync();
        }
    }
}
