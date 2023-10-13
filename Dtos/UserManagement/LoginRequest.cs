////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: LoginRequest.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Data transfer object for login request.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace TravelEase_WebService.Dtos.UserManagement
{
    public class LoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
