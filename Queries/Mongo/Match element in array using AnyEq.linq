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

    //GetAllUsers();   

    GetEmployerUsersAsync("MKKWNP");a
}

public void GetAllUsers()
{
    var collection = GetCollection<User>("users");
    collection.Find(c => 1==1).ToListAsync().Dump();
}


public void GetEmployerUsersAsync(string accountId)
{
    var filter = Builders<User>.Filter.AnyEq(u => u.AccountsDeclaredAsLevyPayers, accountId);
    var collection = GetCollection<User>("users");
    collection.Find(filter).ToListAsync().Dump();
}

protected IMongoCollection<T> GetCollection<T>(string collectionName)
{
    //var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==@localhost:10255/admin?ssl=true"));
    var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://das-test-rcrt-cdb:y3i8IiTt6qDqSkLhTlGxqYION3mFcw8gRhZ2eynGyztjzog7xTQRXGxCHn0s52MVKOOaLYL4hJGs208JIQtHmw==@das-test-rcrt-cdb.documents.azure.com:10255/admin?ssl=true"));
    settings.ClusterConfigurator = cb => cb.Subscribe<MongoDB.Driver.Core.Events.CommandStartedEvent>(e => e.Command.ToJson().Log());
    
    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

    var client = new MongoClient(settings);
    var database = client.GetDatabase("recruit");
    var collection = database.GetCollection<T>(collectionName);

    return collection;
}


public class User
{
    public Guid Id { get; set; }
    public string IdamsUserId { get; set; }
    public UserType UserType { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastSignedInDate { get; set; }
    public IList<string> AccountsDeclaredAsLevyPayers { get; set; } = new List<string>();
    public IList<string> EmployerAccountIds { get; set; } = new List<string>();
    public long? Ukprn { get; set; }
}

public enum UserType
{
    Employer,
    Provider
}