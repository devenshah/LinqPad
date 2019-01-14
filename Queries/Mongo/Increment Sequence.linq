<Query Kind="Program">
  <NuGetReference>MongoDB.Driver</NuGetReference>
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
</Query>

void Main()
{
    var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
    ConventionRegistry.Register("camelCase", conventionPack, t => true);
    
    IncrementSequence();
}

protected int GetNextNumberInTheSequence()
{
    return IncrementSequence().SequenceValue;
}

protected Sequence IncrementSequence()
{
    var collection = GetCollection<Sequence>();
    var options = new FindOneAndUpdateOptions<Sequence>() { ReturnDocument = MongoDB.Driver.ReturnDocument.After };
    var filterQuery = Builders<Sequence>.Filter.Eq(f => f.Id, "MySecondSequence");
    var updateQuery = Builders<Sequence>.Update.Inc(u => u.SequenceValue, 1);
    var doc = collection.FindOneAndUpdate(
        filterQuery, 
        updateQuery, 
        options);
    
    return doc;
}

protected void ReadSequence()
{
    var collection = GetCollection<Sequence>("mySequence");

    var sequence = collection.Find(c => c.Id == "MyFirstSequence").SingleOrDefault();

    sequence.Dump();
}


protected void CreateVacancyDocument()
{
    var id = Guid.NewGuid();
    var collection = GetCollection<Vacancy>("MyDocuments");

    collection.InsertOne(new Vacancy() { Id = id, ReferenceNumber = GetNextNumberInTheSequence(), Title = id.ToString() });
}

protected IMongoCollection<T> GetCollection<T>(string collectionName)
{
    var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==@localhost:10255/admin?ssl=true"));
    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

    var client = new MongoClient(settings);
    var database = client.GetDatabase("Sandbox");
    var collection = database.GetCollection<T>(collectionName);

    return collection;
}


public class Vacancy
{
    public Guid Id { get; set; }

    public int ReferenceNumber { get; set; }

    public string Title { get; set; }

    public DateTime? ClosingDate { get; set; }
}



[BsonIgnoreExtraElements]
public class Sequence
{
    public string Id { get; set; }
    public int SequenceValue { get; set; }
}