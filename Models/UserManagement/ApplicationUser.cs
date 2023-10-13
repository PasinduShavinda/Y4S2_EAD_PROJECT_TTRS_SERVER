////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: ApplicationUser.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Model representing a user in user management.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace TravelEase_WebService.Models.UserManagement
{
    [CollectionName("users")]
    public class ApplicationUser : MongoIdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public string Nic { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public bool IsRequestSent { get; set; } = false;


    }
}

