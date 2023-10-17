////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: TravellerProfileModel.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Model representing a traveler's profile.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TravelEase_WebService.Models.TravellerManagement
{
    [BsonIgnoreExtraElements]
    public class TravellerProfileModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string DOB { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string NIC { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string PrefferedLanguage { get; set; } = string.Empty;
        public string EmergencyContactName { get; set; } = string.Empty;
        public string RelationshipToTraveller { get; set; } = string.Empty;
        public string EmergencyContactNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsProfileCreated { get; set; } = true;
    }
}
