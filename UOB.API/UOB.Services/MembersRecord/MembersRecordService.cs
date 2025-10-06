using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOB.Repository.EF.Entities;
using UOB.Repository.Repositories;
using UOB.Services.MembersRecord.DTO;
using UOB.Shared.Common;
using UOB.Shared.Models.Request;

namespace UOB.Services.MembersRecord
{
    public class MembersRecordService : IMembersRecordService
    {
        private readonly IMemberRecordRepository _recordRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IMemberRepository _memberRepo;

        public MembersRecordService(
            IMemberRecordRepository recordRepo,
            IBookRepository bookRepo,
            IMemberRepository memberRepo)
        {
            _recordRepo = recordRepo;
            _bookRepo = bookRepo;
            _memberRepo = memberRepo;
        }
        public async Task<ApiResponse<string>> BorrowBookAsync(MemberRecordReq req)
        {
            var book = await _bookRepo.GetByIdAsync(req.BookId);
            var member = await _memberRepo.GetByIdAsync(req.MemberId);

            if (book == null || member == null)
                return new ApiResponse<string> { Success = false, Message = "Invalid Book or Member ID." };

            if (!book.IsAvailable)
                return new ApiResponse<string> { Success = false, Message = "Book is already borrowed." };

            var record = new MemberRecord
            {
                Id = Guid.NewGuid(),
                BookId = book.Id,
                MemberId = member.Id,
                BorrowDate = DateTime.UtcNow
            };

            await _recordRepo.AddAsync(record);

            book.IsAvailable = false;
            await _bookRepo.UpdateAsync(book);
            return new ApiResponse<string>
            {
                Success = true,
                Message = "Book borrowed successfully.",
                Data = record.Id.ToString()
            };
        }

        public async Task<ApiResponse<string>> ReturnBookAsync(Guid memberId, Guid bookId)
        {
            var record = (await _recordRepo.GetAllAsync())
                         .FirstOrDefault(r => r.MemberId == memberId && r.BookId == bookId && r.ReturnDate == null);

            if (record == null)
                return new ApiResponse<string> { Success = false, Message = "Borrow record not found." };

            record.ReturnDate = DateTime.UtcNow;
           await _recordRepo.UpdateAsync(record);

            var book = await _bookRepo.GetByIdAsync(bookId);
            if (book != null)
            {
                book.IsAvailable = true;
               await _bookRepo.UpdateAsync(book);
            }
            return new ApiResponse<string> { Success = true, Message = "Book returned successfully." };
        }

        public async Task<ApiResponse<IEnumerable<MemberRecordDTO>>> GetAllAsync()
        {
            var records = await _recordRepo.GetAllAsync();
            var res = records.Select(r => new MemberRecordDTO
            {
                Id = r.Id,
                BookId = r.BookId,
                BookTitle = r.Book.Title,
                MemberId = r.MemberId,
                MemberName = r.Member.Name,
                BorrowDate = r.BorrowDate,
                ReturnDate = r.ReturnDate
            }).ToList();

            return new ApiResponse<IEnumerable<MemberRecordDTO>>
            {
                Success = true,
                Data = res,
                Message = res.Any() ? "Records retrieved successfully." : "No records found."
            };
        }

        public async Task<ApiResponse<IEnumerable<MemberRecordDTO>>> GetByMemberAsync(Guid memberId)
        {
            var records = (await _recordRepo.GetAllAsync()).Where(r => r.MemberId == memberId).ToList();
            var res = records.Select(r => new MemberRecordDTO
            {
                Id = r.Id,
                BookId = r.BookId,
                BookTitle = r.Book.Title,
                MemberId = r.MemberId,
                MemberName = r.Member.Name,
                BorrowDate = r.BorrowDate,
                ReturnDate = r.ReturnDate
            }).ToList();

            return new ApiResponse<IEnumerable<MemberRecordDTO>>
            {
                Success = true,
                Data = res,
                Message = res.Any() ? "Records retrieved successfully." : "No records found."
            };
        }

    }
}
