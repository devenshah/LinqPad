<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference>WindowsAzure.ServiceBus</NuGetReference>
  <Namespace>Microsoft.ServiceBus</Namespace>
  <Namespace>Microsoft.ServiceBus.Channels</Namespace>
  <Namespace>Microsoft.ServiceBus.Common</Namespace>
  <Namespace>Microsoft.ServiceBus.Configuration</Namespace>
  <Namespace>Microsoft.ServiceBus.Description</Namespace>
  <Namespace>Microsoft.ServiceBus.Management</Namespace>
  <Namespace>Microsoft.ServiceBus.Messaging</Namespace>
  <Namespace>Microsoft.ServiceBus.Messaging.Amqp</Namespace>
  <Namespace>Microsoft.ServiceBus.Messaging.Amqp.Serialization</Namespace>
  <Namespace>Microsoft.ServiceBus.Messaging.Configuration</Namespace>
  <Namespace>Microsoft.ServiceBus.Tracing</Namespace>
  <Namespace>Microsoft.ServiceBus.Web</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var connectionString = "Endpoint=sb://sims8integration-local.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=46n2GHT4ICDeAcSAoC9+RCLSbJPuJM43rja8lWTV2Lg=";
	var queueName = "people";
	
	var svc = new ServiceBusService(connectionString, queueName);

	//svc.GetNextMessage().Dump();
	
	//svc.DeleteAllMessages();
	
	//svc.SendMessageToQueue(JsonConvert.SerializeObject(new PeopleSyncMessage("bhai!")));
	
	//Console.WriteLine(svc.PeekMessage());	
	
	Console.WriteLine(svc.GetNextMessage());	
}

// Define other methods and classes here
public class ServiceBusService
{
//	private readonly string _connectionString;
//	private readonly string _queueName;
	private readonly QueueClient _client;
	
	public ServiceBusService(string connectionString, string queueName)
	{
//		_connectionString = connectionString;
//		_queueName = queueName;
		_client = QueueClient.CreateFromConnectionString(connectionString, queueName);
	}
	
	public void SendMessageToQueue(string body, IDictionary<string, object> properties = null)
	{		
		var message = new BrokeredMessage(body);

		if (properties != null && properties.Any())
		{
			foreach (var key in properties.Keys)
			{
				message.Properties.Add(key, properties[key]);
			}
		}
		
		_client.Send(message);
	}

	public string PeekMessage()
	{
		var message = _client.Peek();
		if (message == null) return string.Empty;
		return message.GetBody<string>();
	}
	
	public void DeleteAllMessages()
	{
		var message = _client.Receive(TimeSpan.FromSeconds(10));
		while (message != null)
		{
			message.Complete();
			message = _client.Receive(TimeSpan.FromSeconds(10));			
		}
	}

	public string GetNextMessage()
	{
		var message = _client.Receive(TimeSpan.FromSeconds(10));
		var body = message.GetBody<string>();
		message.Complete();
		return body;
	}
}

public class PeopleSyncMessage
{ 
	public PeopleSyncMessage(string name)
	{
		Name = name;
	}
	public Guid SchoolId { get; set; } = Guid.NewGuid();
	
	public string Name { get; set; }
}