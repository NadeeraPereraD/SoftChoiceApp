using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftChoiceApp.API.Exceptions;
using SoftChoiceApp.API.Interfaces;
using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;

namespace SoftChoiceApp.API.Controllers.UserManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRolesService _userRolesService;

        public UserRolesController(IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRolesCreateDto dto)
        {
            try
            {
                var result = await _userRolesService.CreateAsync(dto);
                bool ok = result.IsSuccess;
                string? error = result.ErrorMessage;
                string? success = result.SuccessMessage;

                if (!ok) return BadRequest(new { error });
                return Ok(new { message = success });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var (roles, error, success) = await _userRolesService.GetAllUserRolesAsync();
                var list = roles;

                if (!string.IsNullOrEmpty(error) && list is not { } || list.Any() is false)
                    return NotFound(new { Message = error });

                return Ok(new
                {
                    Message = success,
                    Data = roles
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }

        [HttpPut("by-keys")]
        public async Task<IActionResult> UpdateByKey([FromBody] UserRolesUpdateDto dto)
        {
            try
            {
                if (dto == null || dto.Id == 0)
                    return BadRequest(new { message = "Id is required in the request body." });
                var result = await _userRolesService.UpdateAsyncByID(dto);
                bool ok = result.IsSuccess;
                string? error = result.ErrorMessage;
                string? success = result.SuccessMessage;
                if (!ok) return BadRequest(new { error });
                return Ok(new { message = success });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }

        [HttpPut("soft-delete-by-keys")]
        public async Task<IActionResult> SoftDeleteByKey([FromBody] UserRolesSoftDeleteDto dto)
        {
            try
            {
                if (dto == null || dto.Id == 0)
                    return BadRequest(new { message = "Id is required in the request body." });
                var result = await _userRolesService.SoftDeleteAsyncByID(dto);
                bool ok = result.IsSuccess;
                string? error = result.ErrorMessage;
                string? success = result.SuccessMessage;
                if (!ok) return BadRequest(new { error });
                return Ok(new { message = success });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }

        [HttpGet]
        [Route("inactive")]
        public async Task<IActionResult> GetAllInactive()
        {
            try
            {
                var (roles, error, success) = await _userRolesService.GetAllInactiveUserRolesAsync();
                var list = roles;

                if (!string.IsNullOrEmpty(error) && list is not { } || list.Any() is false)
                    return NotFound(new { Message = error });

                return Ok(new
                {
                    Message = success,
                    Data = roles
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }
    }
}
