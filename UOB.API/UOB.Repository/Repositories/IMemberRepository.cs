

using UOB.Repository.EF.Entities;

namespace UOB.Repository.Repositories
{
    public interface IMemberRepository
    {
        Task<int> AddAsync(Members newMember);
        Task<int> Delete(Members member);
        Task<IEnumerable<Members>> GetAllAsync();
        Task<Members?> GetByIdAsync(Guid id);
        Task<int> Update(Members existingMember);
    }
}