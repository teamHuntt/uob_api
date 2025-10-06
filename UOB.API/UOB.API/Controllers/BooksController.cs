using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UOB.Repository.EF.Entities;
using UOB.Services.Books;
using UOB.Shared.Models.Request;

namespace UOB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        /// <summary>
        /// Return all books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _bookService.GetAllAsync();
            if (res.Success)
            {
                return Ok(res);
            }
            return NotFound(res);
        }
        /// <summary>
        /// Fetch book by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _bookService.GetByIdAsync(id);

            if (res.Success)
            {
                return Ok(res);
            }
            return NotFound(res);
        }
        /// <summary>
        /// Return all the available books
        /// </summary>
        /// <returns></returns>
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var res = await _bookService.GetAvailableBooksAsync();
            if (res.Success)
            {
                return Ok(res);
            }
            return NotFound(res);
        }
        /// <summary>
        /// Create a new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BookReq book)
        {
            var res = await _bookService.AddAsync(book);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromForm] BookReq book)
        {
            var res = await _bookService.UpdateAsync(book);
            if (res.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        /// <summary>
        /// Delete a boook
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
