using UOB.Repository.EF.Entities;

namespace UOB.Repository.Repositories
{
    public interface IMemberRecordRepository
    {
        Task<int> AddAsync(MemberRecord record);
        Task<List<MemberRecord>> GetAllAsync();
        Task<int> UpdateAsync(MemberRecord record);
    }
}