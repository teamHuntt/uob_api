using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOB.Services.Member.DTO;
using UOB.Shared.Common;
using UOB.Shared.Models.Request;

namespace UOB.Services.Member
{
    public interface IMemberService
    {
        Task<ApiResponse<IEnumerable<MemberDTO>>> GetAllAsync();
        Task<ApiResponse<MemberDTO?>> GetByIdAsync(Guid id);
        Task<ApiResponse<string>> AddAsync(MemberReq req);
        Task<ApiResponse<MemberDTO>> UpdateAsync(MemberReq req);
        Task<ApiResponse<string>> DeleteAsync(Guid id);
    }
}
