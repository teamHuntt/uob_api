using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UOB.Services.Member;
using UOB.Shared.Models.Request;

namespace UOB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        /// <summary>
        /// Get all members
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _memberService.GetAllAsync();
            return res.Success ? Ok(res) : NotFound(res);
        }
        /// <summary>
        /// Get member by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _memberService.GetByIdAsync(id);
            return res.Success ? Ok(res) : NotFound(res);
        }
        /// <summary>
        /// Create a new member
        /// </summary>
        /// <param name="req"></param>
        /// <returns>Details of member</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MemberReq req)
        {
            var res = await _memberService.AddAsync(req);
            return res.Success ? Ok(res) : BadRequest(res);
        }
        /// <summary>
        /// Update the member
        /// </summary>
        /// <param name="req"></param>
        /// <returns>Msg of task</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromForm] MemberReq req)
        {
            var res = await _memberService.UpdateAsync(req);
            return res.Success ? Ok(res) : BadRequest(res);
        }
        /// <summary>
        /// Delete the member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _memberService.DeleteAsync(id);
            return res.Success ? Ok(res) : BadRequest(res);
        }
    }
}
