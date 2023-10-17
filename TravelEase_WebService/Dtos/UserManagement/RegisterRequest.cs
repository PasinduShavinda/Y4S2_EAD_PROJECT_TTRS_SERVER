////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: RegisterRequest.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Data transfer object for user registration request.
//////////////////////////

using System.ComponentModel.DataAnnotations;

namespace TravelEase_WebService.Dtos.UserManagement
{
    public class RegisterRequest
    {
        public string Nic { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required, DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public bool IsRequestSent { get; set; }

        public bool IsProfileCreated { get; set; }
    }
}

