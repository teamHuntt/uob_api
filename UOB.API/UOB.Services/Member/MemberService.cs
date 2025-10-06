using UOB.Repository.Repositories;
using UOB.Services.Member.DTO;
using UOB.Shared.Common;
using UOB.Shared.Models.Request;
using UOB.Repository.EF.Entities;

namespace UOB.Services.Member
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepo;

        public MemberService(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<ApiResponse<IEnumerable<MemberDTO>>> GetAllAsync()
        {
            var members = await _memberRepo.GetAllAsync();
            var res = members.Select(m => new MemberDTO
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                IsActive = m.IsActive,
            }).ToList();

            return new ApiResponse<IEnumerable<MemberDTO>>
            {
                Data = res,
                Success = true,
                Message = res.Any() ? "Members retrieved successfully." : "No members found."
            };
        }

        public async Task<ApiResponse<MemberDTO?>> GetByIdAsync(Guid id)
        {
            var member = await _memberRepo.GetByIdAsync(id);
            if (member != null)
            {
                return new ApiResponse<MemberDTO?>
                {
                    Data = new MemberDTO
                    {
                        Id = member.Id,
                        Name = member.Name,
                        Email = member.Email
                    },
                    Success = true,
                    Message = "Member retrieved successfully."
                };
            }
            return new ApiResponse<MemberDTO?>
            {
                Success = false,
                Message = "Member not found."
            };
        }

        public async Task<ApiResponse<string>> AddAsync(MemberReq req)
        {
            if (req != null)
            {
                var newMember = new Members
                {
                    Id = Guid.NewGuid(),
                    Name = req.Name,
                    Email = req.Email,
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                };
                int res = await _memberRepo.AddAsync(newMember);
                if (res > 0)
                {
                    return new ApiResponse<string>
                    {
                        Data = newMember.Id.ToString(),
                        Success = true,
                        Message = "Member added successfully."
                    };
                }
            }
            return new ApiResponse<string>
            {
                Success = false,
                Message = "Failed to add member."
            };
        }

        public async Task<ApiResponse<MemberDTO>> UpdateAsync(MemberReq req)
        {
            var existingMember = await _memberRepo.GetByIdAsync(req.Id);
            if (existingMember != null)
            {
                existingMember.Name = req.Name;
                existingMember.Email = req.Email;
                existingMember.UpdatedDate = DateTime.UtcNow;
                existingMember.UpdatedBy = "System"; // This should ideally come from the authenticated user context
                existingMember.IsActive = req.IsActive;
                int res = await _memberRepo.Update(existingMember);
                if (res > 0)
                {
                    return new ApiResponse<MemberDTO>
                    {
                        Data = new MemberDTO
                        {
                            Id = existingMember.Id,
                            Name = existingMember.Name,
                            Email = existingMember.Email,
                            IsActive = existingMember.IsActive
                        },
                        Success = true,
                        Message = "Member updated successfully."
                    };
                }
            }

            return new ApiResponse<MemberDTO>
            {
                Success = false,
                Message = "Failed to update member."
            };
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var member = await _memberRepo.GetByIdAsync(id);
            if (member != null)
            {
                int res = await _memberRepo.Delete(member);
                if (res > 0)
                {
                    return new ApiResponse<string>
                    {
                        Success = true,
                        Message = "Member deleted successfully."
                    };
                }
            }

            return new ApiResponse<string>
            {
                Success = false,
                Message = "Failed to delete member."
            };
        }
    }
}
