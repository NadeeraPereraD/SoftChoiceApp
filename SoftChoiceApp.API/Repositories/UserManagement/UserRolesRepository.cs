using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SoftChoiceApp.API.Data;
using SoftChoiceApp.API.Interfaces;
using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;
using System.Data;

namespace SoftChoiceApp.API.Repositories.UserManagement
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly AppDbContext _context;

        public UserRolesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UserRolesCreateDto dto)
        {
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "usp_UserRoles_Create";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Role", dto.Role));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@CreatedBy", dto.CreatedBy));

                var pError = new Microsoft.Data.SqlClient.SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(pError);

                var pSuccess = new Microsoft.Data.SqlClient.SqlParameter("@SuccessMessage", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(pSuccess);
                await cmd.ExecuteNonQueryAsync();
                var errorMsg = pError.Value as string;
                var successMsg = pSuccess.Value as string;
                var isSuccess = string.IsNullOrEmpty(errorMsg);

                return (isSuccess, errorMsg, successMsg);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<(IEnumerable<UserRole> userRoles, string? ErrorMessage, string? SuccessMessage)> GetAllAsync()
        {
            try
            {
                var errorParam = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };
                var successParam = new SqlParameter("@SuccessMessage", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };

                var roles = await _context.UserRoles
                    .FromSqlRaw("EXEC dbo.usp_UserRoles_GetAll @ErrorMessage OUTPUT, @SuccessMessage OUTPUT",
                                 errorParam, successParam)
                    .ToListAsync();

                var errorMsg = errorParam.Value as string;
                var successMsg = successParam.Value as string;

                return (roles, errorMsg, successMsg);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public async Task<(UserRole? Entity, string? ErrorMessage, string? SuccessMessage)> GetByKeyAsync(string Role);
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> UpdateByKeyAsync(UserRolesUpdateDto dto)
        {
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "usp_UserRoles_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Id", dto.Id));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Role", dto.Role));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@UpdatedBy", dto.UpdatedBy));

                var pError = new Microsoft.Data.SqlClient.SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(pError);

                var pSuccess = new Microsoft.Data.SqlClient.SqlParameter("@SuccessMessage", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(pSuccess);
                await cmd.ExecuteNonQueryAsync();
                var errorMsg = pError.Value as string;
                var successMsg = pSuccess.Value as string;
                var isSuccess = string.IsNullOrEmpty(errorMsg);

                return (isSuccess, errorMsg, successMsg);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> SoftDeleteByKeyAsync(UserRolesSoftDeleteDto dto)
        {
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "usp_UserRoles_SoftDelete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Id", dto.Id));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@UpdatedBy", dto.UpdatedBy));

                var pError = new Microsoft.Data.SqlClient.SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(pError);

                var pSuccess = new Microsoft.Data.SqlClient.SqlParameter("@SuccessMessage", SqlDbType.NVarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(pSuccess);
                await cmd.ExecuteNonQueryAsync();
                var errorMsg = pError.Value as string;
                var successMsg = pSuccess.Value as string;
                var isSuccess = string.IsNullOrEmpty(errorMsg);

                return (isSuccess, errorMsg, successMsg);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<(IEnumerable<UserRole> userRoles, string? ErrorMessage, string? SuccessMessage)> GetAllInactiveAsync()
        {
            try
            {
                var errorParam = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };
                var successParam = new SqlParameter("@SuccessMessage", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };

                var roles = await _context.UserRoles
                    .FromSqlRaw("EXEC dbo.usp_UserRoles_GetAll_Inactive @ErrorMessage OUTPUT, @SuccessMessage OUTPUT",
                                 errorParam, successParam)
                    .ToListAsync();

                var errorMsg = errorParam.Value as string;
                var successMsg = successParam.Value as string;

                return (roles, errorMsg, successMsg);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
