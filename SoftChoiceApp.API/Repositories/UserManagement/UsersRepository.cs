using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SoftChoiceApp.API.Data;
using SoftChoiceApp.API.Interfaces;
using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;
using SoftChoiceApp.API.Models.Entities;
using System.Data;

namespace SoftChoiceApp.API.Repositories.UserManagement
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _context;
        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> CreateAsync(UsersCreateDto dto)
        {
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "usp_Users_Create";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@FirstName", dto.FirstName));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@LastName", dto.LastName));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@UserName", dto.UserName));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Password", dto.Password));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Email", dto.Email));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Mobile", dto.Mobile));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Address", dto.Address));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@NIC", dto.NIC));
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
        public async Task<(IEnumerable<User> users, string? ErrorMessage, string? SuccessMessage)> GetAllAsync()
        {
            try
            {
                var errorParam = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };
                var successParam = new SqlParameter("@SuccessMessage", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };

                var users = await _context.Users
                    .FromSqlRaw("EXEC dbo.usp_Users_GetAll @ErrorMessage OUTPUT, @SuccessMessage OUTPUT",
                                 errorParam, successParam)
                    .ToListAsync();

                var errorMsg = errorParam.Value as string;
                var successMsg = successParam.Value as string;

                return (users, errorMsg, successMsg);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> UpdateByKeyAsync(UsersUpdateDto dto)
        {
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "usp_Users_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Id", dto.Id));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@FirstName", dto.FirstName));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@LastName", dto.LastName));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@UserName", dto.UserName));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Password", dto.Password));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Email", dto.Email));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Mobile", dto.Mobile));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Address", dto.Address));
                cmd.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@NIC", dto.NIC));
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
        public async Task<(bool IsSuccess, string? ErrorMessage, string? SuccessMessage)> SoftDeleteByKeyAsync(UsersSoftDeleteDto dto)
        {
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "usp_Users_SoftDelete";
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
        public async Task<(IEnumerable<User> users, string? ErrorMessage, string? SuccessMessage)> GetAllInactiveAsync()
        {
            try
            {
                var errorParam = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };
                var successParam = new SqlParameter("@SuccessMessage", SqlDbType.NVarChar, 500) { Direction = ParameterDirection.Output };

                var users = await _context.Users
                    .FromSqlRaw("EXEC dbo.usp_Users_GetAll_Inactive @ErrorMessage OUTPUT, @SuccessMessage OUTPUT",
                                 errorParam, successParam)
                    .ToListAsync();

                var errorMsg = errorParam.Value as string;
                var successMsg = successParam.Value as string;

                return (users, errorMsg, successMsg);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
