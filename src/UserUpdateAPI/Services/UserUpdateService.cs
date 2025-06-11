using System.Threading.Tasks;

namespace UserUpdateAPI.Services
{
    public interface IUserUpdateService
    {
        Task<UserUpdateResult> UpdateUserAsync(int id, UserUpdateRequest request);
    }

    public class UserUpdateService : IUserUpdateService
    {
        public async Task<UserUpdateResult> UpdateUserAsync(int id, UserUpdateRequest request)
        {
            // Simulate user update logic
            if (id <= 0)
            {
                return new UserUpdateResult
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = "Invalid user ID."
                };
            }

            // Simulate success
            return new UserUpdateResult
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = "User updated successfully."
            };
        }
    }

    public class UserUpdateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UserUpdateResult
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}