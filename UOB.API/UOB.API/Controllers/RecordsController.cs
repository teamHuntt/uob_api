using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UOB.Services.MembersRecord;
using UOB.Shared.Models.Request;

namespace UOB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IMembersRecordService _records;
        public RecordsController(IMembersRecordService membersRecordService)
        {
            _records = membersRecordService;
        }


        [HttpPost("borrow")]
        public async Task<IActionResult> Borrow([FromForm] MemberRecordReq req)
        {
            var res = await _records.BorrowBookAsync(req);
            return res.Success ? Ok(res) : BadRequest(res);
        }

        /// <summary>
        /// Return a book
        /// </summary>
        [HttpPost("return")]
        public async Task<IActionResult> Return([FromForm] Guid memberId, [FromForm] Guid bookId)
        {
            var res = await _records.ReturnBookAsync(memberId, bookId);
            return res.Success ? Ok(res) : BadRequest(res);
        }

        /// <summary>
        /// Get all borrow records
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _records.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("member/{memberId}")]
        public async Task<IActionResult> GetByMember(Guid memberId)
        {
            var res = await _records.GetByMemberAsync(memberId);
            return Ok(res);
        }
    }
}
