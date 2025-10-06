using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOB.Repository.EF.Entities;
using UOB.Shared.Common;
using UOB.Shared.Models.Request;

namespace UOB.Services.Books
{
    public interface IBookService
    {
        Task<ApiResponse<IEnumerable<BooksDTO>>> GetAllAsync();
        Task<ApiResponse<BooksDTO?>> GetByIdAsync(Guid id);
        Task<ApiResponse<IEnumerable<BooksDTO>>> GetAvailableBooksAsync();
        Task<ApiResponse<string>> AddAsync(BookReq book);
        Task<ApiResponse<BooksDTO>>UpdateAsync(BookReq book);
        Task<ApiResponse<string>> DeleteAsync(Guid id);
    }
}
