using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace TravelEase_WebService.Models.TravellerManagement;

public class TravellerProfileModel {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
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
}