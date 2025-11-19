using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftChoiceApp.API.Exceptions;
using SoftChoiceApp.API.Interfaces;
using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Services.UserManagement;

namespace SoftChoiceApp.API.Controllers.UserManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [Authorize(Roles = "1,2")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsersCreateDto dto)
        {
            try
            {
                var result = await _usersService.CreateAsync(dto);
                bool ok = result.IsSuccess;
                string? error = result.ErrorMessage;
                string? success = result.SuccessMessage;

                if (!ok) return BadRequest(new { error });
                return Ok(new { message = success });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Not found error occurred.");
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt.");
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                _logger.LogWarning(ex, "Forbidden access.");
                return Forbid();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected server error.");
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var (users, error, success) = await _usersService.GetAllUsersAsync();
                var list = users;

                if (!string.IsNullOrEmpty(error) && list is not { } || list.Any() is false)
                    return NotFound(new { Message = error });

                return Ok(new
                {
                    Message = success,
                    Data = users
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Not found error occurred.");
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt.");
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                _logger.LogWarning(ex, "Forbidden access.");
                return Forbid();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected server error.");
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpPut("by-keys")]
        public async Task<IActionResult> UpdateByKey([FromBody] UsersUpdateDto dto)
        {
            try
            {
                if (dto == null || dto.Id == 0)
                    return BadRequest(new { message = "Id is required in the request body." });
                var result = await _usersService.UpdateAsyncByID(dto);
                bool ok = result.IsSuccess;
                string? error = result.ErrorMessage;
                string? success = result.SuccessMessage;
                if (!ok) return BadRequest(new { error });
                return Ok(new { message = success });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Not found error occurred.");
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt.");
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                _logger.LogWarning(ex, "Forbidden access.");
                return Forbid();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected server error.");
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpPut("soft-delete-by-keys")]
        public async Task<IActionResult> SoftDeleteByKey([FromBody] UsersSoftDeleteDto dto)
        {
            try
            {
                if (dto == null || dto.Id == 0)
                    return BadRequest(new { message = "Id is required in the request body." });
                var result = await _usersService.SoftDeleteAsyncByID(dto);
                bool ok = result.IsSuccess;
                string? error = result.ErrorMessage;
                string? success = result.SuccessMessage;
                if (!ok) return BadRequest(new { error });
                return Ok(new { message = success });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Not found error occurred.");
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt.");
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                _logger.LogWarning(ex, "Forbidden access.");
                return Forbid();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected server error.");
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        [Route("inactive")]
        public async Task<IActionResult> GetAllInactive()
        {
            try
            {
                var (users, error, success) = await _usersService.GetAllInactiveUserRolesAsync();
                var list = users;

                if (!string.IsNullOrEmpty(error) && list is not { } || list.Any() is false)
                    return NotFound(new { Message = error });

                return Ok(new
                {
                    Message = success,
                    Data = users
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Not found error occurred.");
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt.");
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                _logger.LogWarning(ex, "Forbidden access.");
                return Forbid();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected server error.");
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            try
            {
                var result = await _usersService.LoginAsync(dto);

                if (!result.IsSuccess)
                    return Unauthorized(new { message = result.ErrorMessage });

                return Ok(new { token = result.Token });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Not found error occurred.");
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessAppException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access attempt.");
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ForbiddenAccessException ex)
            {
                _logger.LogWarning(ex, "Forbidden access.");
                return Forbid();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected server error.");
                return StatusCode(500, new { Message = "Internal server error", Details = ex.Message });
            }
        }

    }
}
