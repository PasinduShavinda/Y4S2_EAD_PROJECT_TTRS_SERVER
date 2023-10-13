////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: ReservationDetails.cs
//FileType: Visual C# Source file
//Author : Kalansooriya S. H
//Description :DB model class for train scheduls
////////////////////////////////////////////////////////////////////////////////////////////////////////

using MongoDB.Driver;
using TravelEase_WebService.TrainModels;

public class TrainDbContext
{
    private readonly IMongoDatabase _database;

    public TrainDbContext(IMongoClient client, string databaseName)
    {
        _database = client.GetDatabase(databaseName);
    }

    
}
