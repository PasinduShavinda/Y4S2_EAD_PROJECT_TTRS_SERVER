////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: MongoDBSettings.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Configuration settings for MongoDB database connection.
////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TravelEase_WebService.Models.DBSettings
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName1 { get; set; } = null!;
        public string CollectionName2 { get; set; } = null!;
    }
}
