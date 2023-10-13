////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: ApplicationRole.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Model representing an application role in user management.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace TravelEase_WebService.Models.UserManagement
{
    [CollectionName("roles")]
    public class ApplicationRole : MongoIdentityRole<Guid>
    {
        
    }
}

