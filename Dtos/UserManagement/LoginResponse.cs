////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: LoginResponse.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Data transfer object for login response.
////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TravelEase_WebService.Dtos.UserManagement
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Nic { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
