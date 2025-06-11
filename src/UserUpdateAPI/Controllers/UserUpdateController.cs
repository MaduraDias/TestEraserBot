using Microsoft.AspNetCore.Mvc;

namespace UserUpdateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserUpdateController : ControllerBase
    {
        private readonly IUserUpdateService _userUpdateService;

        public UserUpdateController(IUserUpdateService userUpdateService)
        {
            _userUpdateService = userUpdateService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateRequest request)
        {
            var result = await _userUpdateService.UpdateUserAsync(id, request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return StatusCode(result.StatusCode, result.Message);
        }
    }
}