<Query Kind="Program">
  <NuGetReference>CsvHelper</NuGetReference>
  <NuGetReference>MongoDB.Bson</NuGetReference>
  <NuGetReference>MongoDB.Driver</NuGetReference>
  <Namespace>CsvHelper</Namespace>
  <Namespace>CsvHelper.Configuration</Namespace>
  <Namespace>DnsClient</Namespace>
  <Namespace>DnsClient.Protocol</Namespace>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.IO</Namespace>
  <Namespace>MongoDB.Bson.Serialization</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Attributes</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Conventions</Namespace>
  <Namespace>MongoDB.Bson.Serialization.IdGenerators</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Options</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Serializers</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>MongoDB.Driver.Core.Authentication</Namespace>
  <Namespace>MongoDB.Driver.Core.Authentication.Sspi</Namespace>
  <Namespace>MongoDB.Driver.Core.Authentication.Vendored</Namespace>
  <Namespace>MongoDB.Driver.Core.Bindings</Namespace>
  <Namespace>MongoDB.Driver.Core.Clusters</Namespace>
  <Namespace>MongoDB.Driver.Core.Clusters.ServerSelectors</Namespace>
  <Namespace>MongoDB.Driver.Core.Configuration</Namespace>
  <Namespace>MongoDB.Driver.Core.ConnectionPools</Namespace>
  <Namespace>MongoDB.Driver.Core.Connections</Namespace>
  <Namespace>MongoDB.Driver.Core.Events</Namespace>
  <Namespace>MongoDB.Driver.Core.Events.Diagnostics</Namespace>
  <Namespace>MongoDB.Driver.Core.Misc</Namespace>
  <Namespace>MongoDB.Driver.Core.Operations</Namespace>
  <Namespace>MongoDB.Driver.Core.Operations.ElementNameValidators</Namespace>
  <Namespace>MongoDB.Driver.Core.Servers</Namespace>
  <Namespace>MongoDB.Driver.Core.WireProtocol</Namespace>
  <Namespace>MongoDB.Driver.Core.WireProtocol.Messages</Namespace>
  <Namespace>MongoDB.Driver.Core.WireProtocol.Messages.Encoders</Namespace>
  <Namespace>MongoDB.Driver.Core.WireProtocol.Messages.Encoders.BinaryEncoders</Namespace>
  <Namespace>MongoDB.Driver.Core.WireProtocol.Messages.Encoders.JsonEncoders</Namespace>
  <Namespace>MongoDB.Driver.GeoJsonObjectModel</Namespace>
  <Namespace>MongoDB.Driver.GeoJsonObjectModel.Serializers</Namespace>
  <Namespace>MongoDB.Driver.Linq</Namespace>
  <Namespace>System.Buffers</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Security.Authentication</Namespace>
  <Namespace>System</Namespace>
</Query>

void Main()
{
    var settings = new MongoClientSettings()
    {
        Server = new MongoServerAddress("das-pp-faa-cdb.documents.azure.com", 10255),
        UseSsl = true,
        SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 },
        ConnectionMode = ConnectionMode.Direct,
        Credential = MongoCredential.CreateCredential("admin", "das-pp-faa-cdb", "GEacUajgjaZoVFUvJlEPUUVZdxvKAlN3Hwsk45HMgZ9gT7gOmafrCcu0ppyevjXbxDPM5ydyrvNdDWxFN9FWnQ==")
        //Credential = new MongoCredential("SCRAM-SHA-1", new MongoInternalIdentity(DatabaseName, UserName), new PasswordEvidence(Password) )
    };

    var client = new MongoClient(settings);

    var database = client.GetDatabase("findapprenticeship");
    var collection = database.GetCollection<ApplicationDetail>("apprenticeships");

    var filter = Builders<ApplicationDetail>.Filter.Empty;
    var totalDocs = collection.Find(filter).Count();

    var doc = collection.Find(filter).Skip(1).First(); //collection.Find(filter).First().Dump();
    
    Func<int, Guid, FilterDefinition<ApplicationDetail>> idFilter = (vacancyId, candidateId) => Builders<ApplicationDetail>.Filter.Eq(f => f.Vacancy.Id, vacancyId) & Builders<ApplicationDetail>.Filter.Eq(f => f.CandidateId, candidateId) ;
    
    collection.UpdateOne(idFilter(doc.Vacancy.Id, doc.CandidateId), Builders<ApplicationDetail>.Update.Set(u => u.Notes, doc.Id.ToString()));
    
    collection.Find(idFilter(doc.Vacancy.Id, doc.CandidateId)).First().Dump();
}

[BsonIgnoreExtraElements]
public class ApplicationDetail : BaseDocument
{
    public string Notes { get; set; }
    
    public Guid CandidateId { get; set; }
    
    public Vacancy Vacancy { get; set; }
}

[BsonIgnoreExtraElements]
public class Vacancy 
{
    public int Id { get; set; }
}

public class BaseDocument
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }

}