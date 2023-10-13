////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: RegisteredTravellerModel.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Model representing a registered traveler.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TravelEase_WebService.Models.TravellerManagement
{
    [BsonIgnoreExtraElements]
    public class RegisteredTravellerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string>? Roles { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Nic { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsRequestSent { get; set; }
    }
}
