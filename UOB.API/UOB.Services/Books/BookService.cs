using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOB.Repository.EF.Entities;
using UOB.Repository.Repositories;
using UOB.Shared.Common;
using UOB.Shared.Models.Request;

namespace UOB.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<ApiResponse<IEnumerable<BooksDTO>>> GetAllAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            var res = books.Select(b => new BooksDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                IsAvailable = b.IsAvailable
            }).ToList();
            return new ApiResponse<IEnumerable<BooksDTO>>
            {
                Data = res,
                Success = true,
                Message = res.Any()
               ? "Books retrieved successfully."
               : "No books found."
            };
        }

        public async Task<ApiResponse<BooksDTO?>> GetByIdAsync(Guid id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book != null)
            {

                return new ApiResponse<BooksDTO?>
                {
                    Data = new BooksDTO
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        IsAvailable = book.IsAvailable
                    },
                    Message = "Book retrieved successfully",
                    Success = true
                };
            }
            return new ApiResponse<BooksDTO?>
            {
                Success = false,
                Message = "Record not found"
            };
        }

        public async Task<ApiResponse<IEnumerable<BooksDTO>>> GetAvailableBooksAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            var res = books.Where(x => x.IsAvailable).Select(b => new BooksDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                IsAvailable = b.IsAvailable
            }).ToList();

            return new ApiResponse<IEnumerable<BooksDTO>>
            {
                Data = res,
                Success = true,
                Message = res.Any()
             ? "Books retrieved successfully."
             : "No books found."
            };
        }

        public async Task<ApiResponse<string>> AddAsync(BookReq req)
        {
            if (req != null)
            {
                var newBook = new Book
                {
                    Author = req.Author,
                    Id = Guid.NewGuid(),
                    IsAvailable = true,
                    Title = req.Title
                };
                int res = await _bookRepo.AddAsync(newBook);
                if (res > 0)
                {
                    return new ApiResponse<string>
                    {
                        Data = newBook.Id.ToString(),
                        Message = "Book added successfully",
                        Success = true,
                    };
                }
            }
            return new ApiResponse<string>
            {
                Message = "Failed to add record",
                Success = false,
            };
        }

        public async Task<ApiResponse<BooksDTO>> UpdateAsync(BookReq book)
        {
            var existingBook = await _bookRepo.GetByIdAsync(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.IsAvailable= book.IsAvailable;

                int res = await _bookRepo.UpdateAsync(existingBook);
                if (res > 0)
                {
                    return new ApiResponse<BooksDTO>
                    {
                        Data = new BooksDTO
                        {
                            Id = existingBook.Id,
                            Title = existingBook.Title,
                            Author = existingBook.Author,
                            IsAvailable = existingBook.IsAvailable
                        },
                        Message = "Book updated successfully",
                        Success = true
                    };
                }
            }
            return new ApiResponse<BooksDTO>
            {
                Message = "Invalid request",
                Success = true
            };
        }

        public async Task<ApiResponse<string>> DeleteAsync(Guid id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book != null)
            {
                int res = await _bookRepo.Delete(book);
                if (res > 0)
                {
                    return new ApiResponse<string>
                    {
                        Message = "Book deleted successfully",
                        Success = true
                    };
                }
            }
            return new ApiResponse<string>
            {
                Message = "Failed to delete record",
                Success = false,
            };
        }
    }
}
