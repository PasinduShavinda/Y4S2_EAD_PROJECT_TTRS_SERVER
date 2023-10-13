////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: RegisterResponse.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Data transfer object for user registration response.
////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TravelEase_WebService.Dtos.UserManagement
{
    public class RegisterResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
    }
}

