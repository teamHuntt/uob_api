using UOB.Services.MembersRecord.DTO;
using UOB.Shared.Common;
using UOB.Shared.Models.Request;

namespace UOB.Services.MembersRecord
{
    public interface IMembersRecordService
    {
        Task<ApiResponse<string>> BorrowBookAsync(MemberRecordReq req);
        Task<ApiResponse<string>> ReturnBookAsync(Guid memberId, Guid bookId);
        Task<ApiResponse<IEnumerable<MemberRecordDTO>>> GetAllAsync();
        Task<ApiResponse<IEnumerable<MemberRecordDTO>>> GetByMemberAsync(Guid memberId);
    }
}