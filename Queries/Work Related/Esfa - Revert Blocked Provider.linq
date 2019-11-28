<Query Kind="Program">
  <NuGetReference>Microsoft.WindowsAzure.ConfigurationManager</NuGetReference>
  <NuGetReference>MongoDB.Driver</NuGetReference>
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>DnsClient</Namespace>
  <Namespace>DnsClient.Protocol</Namespace>
  <Namespace>Microsoft.Azure</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Queue</Namespace>
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
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="StorageConnectionString" value="DefaultEndpointsProtocol=https;AccountName=functionpocstore;AccountKey=Fj7zTdqOyQBteBzbhMX6KYmbsRExyLPb21r5BIrSJU9EMd7w/B7C8LtsRUbFhxPSyW9wgrO7gN/ZsWvspGksHg==" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

void Main()
{ 
    var ukprn = 1000400;
    DeleteBlockedOrganisation(ukprn.ToString());
    UpdateQueryStore();
}

void DeleteBlockedOrganisation(string ukprn)
{
    var collection = GetCollection<BlockedOrganisation>("blockedOrganisations");
    var filterBuilder = Builders<BlockedOrganisation>.Filter;

    var filter = filterBuilder.Eq("organisationId", ukprn);
    
    //collection.Find(filter).ToList().Dump();
    
    collection.DeleteOne(filter).Dump(); 
}

protected IMongoCollection<T> GetCollection<T>(string collectionName)
{
    var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://das-test-rcrt-cdb:y3i8IiTt6qDqSkLhTlGxqYION3mFcw8gRhZ2eynGyztjzog7xTQRXGxCHn0s52MVKOOaLYL4hJGs208JIQtHmw==@das-test-rcrt-cdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb"));
    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

    var client = new MongoClient(settings);
    var database = client.GetDatabase("recruit");
    var collection = database.GetCollection<T>(collectionName);

    return collection;
}

public class BlockedOrganisation
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    public ObjectId Id { get; set; }
    public string organisationType { get; set; }
    public string organisationId { get; set; }
    public string blockedStatus { get; set; }
    public DateTime updatedDate { get; set; }
    public string reason { get; set; }
    public object updatedByUser { get; set; }
}

void UpdateQueryStore()
{
    var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=dastestrcrtstr;AccountKey=B2rLvVVP6a7yT3y+LfQE5n5wAEokaNC54bssNPNQkz5DkvPNos+LpwqLm1vqYKHdtdIB8BULHNf0dbldCYQzQQ==;EndpointSuffix=core.windows.net");
		
	var queueClient = storageAccount.CreateCloudQueueClient();
	
	var queue = queueClient.GetQueueReference("generate-all-blocked-organisations-queue");
	
	queue.CreateIfNotExists();

	var message = new CloudQueueMessage("Bazinga!!!");
	queue.AddMessage(message);

}

