<Query Kind="Program">
  <NuGetReference>AutoMapper</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference>Unity</NuGetReference>
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
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

const string SchoolUpdate = "SchoolUpdate";
const string AllMessages = "AllMessages";
const string NewSchool = "NewSchool";

const string connectionString = "Endpoint=sb://simslabs-servicebus-backbone-local.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Y31in3tSbHBBBtixD7CXd4YkOG5PNkn5aVRyXnow5jQ=";

static CancellationTokenSource tokenSource = new CancellationTokenSource();

void Main()
{
	SendMessage(GetSchoolUpdateMessage());
}

BrokeredMessage GetSchoolUpdateMessage()
{
	return new BrokeredMessage(
		JsonConvert.SerializeObject(
			new SchoolUpdateMessage() {
				SchoolGuid = Guid.Parse("4c86d0da-ed06-46bd-a3c7-c0386a3a44e1"),
				SchoolName = "FALTU",
				UsesSimsPrimary = false
			}));
}

void FullProcess()
{
	CreateTopicAndSubscriptions();

	var tasks = new Task[3];
	tasks[0] = Task.Run(() => ListenToAllMessages());
	tasks[1] = Task.Run(() => ListenToFilteredMessages());
	tasks[2] = Task.Run(() => SendMessages(GetMessages()))
		//once the messages are sent wait for 30 seconds
		.ContinueWith((t) =>
		{
			Thread.Sleep(TimeSpan.FromSeconds(30));
			Console.WriteLine("Cancelling token now");
			tokenSource.Cancel();		
        });
	
	Task.WaitAll(tasks);

	
	//SendMessages();
//	ListenToAllMessages();
	Console.WriteLine("Thread has ended!");	
}

void CreateTopicAndSubscriptions()
{
	var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

	//Create topic
	if (!namespaceManager.TopicExists(SchoolUpdate))
	{
		namespaceManager.CreateTopic(SchoolUpdate);
	}

	//Create subscription for all the messages
	if (!namespaceManager.SubscriptionExists(SchoolUpdate, AllMessages))
	{
		namespaceManager.CreateSubscription(SchoolUpdate, AllMessages);
	}

	//Create subscription with filter
	if (!namespaceManager.SubscriptionExists(SchoolUpdate, NewSchool))
	{
		var newSchoolFilter = new SqlFilter("NewSchool = '1'");
		namespaceManager.CreateSubscription(SchoolUpdate, NewSchool, newSchoolFilter);
	}
}

void SendMessages(List<BrokeredMessage> messages)
{
	messages.ForEach(msg => {
		SendMessage(msg);
	});
	Console.WriteLine("Finished sending all messages");
}

void SendMessage(BrokeredMessage message)
{
	var client = TopicClient.CreateFromConnectionString(connectionString, SchoolUpdate);
	client.Send(message);
}

public class SchoolUpdateMessage
{
	public string IdentitySource { get; set; }
	public bool IsActive { get; set; }
	public bool IsDeleted { get; set; }
	public bool IsTestSchool { get; set; }
	public string LeaNumber { get; set; }
	public IEnumerable<string> Licenses { get; set; }
	public string Postcode { get; set; }
	public string PrimaryEmailAddress { get; set; }
	public Guid SchoolGuid { get; set; }
	public int SchoolId { get; set; }
	public string SchoolName { get; set; }
	public string SchoolNumber { get; set; }
	public bool UsesSimsPrimary { get; set; }
}

List<BrokeredMessage> GetMessages()
{
	var result = new List<BrokeredMessage>();	
	
	var msg3 = new BrokeredMessage("Third Message");
	msg3.MessageId = "3";
	msg3.Properties["NewSchool"] = "1";
	result.Add(msg3);

	var msg2 = new BrokeredMessage("Second Message");
	msg2.MessageId = "2";
	msg2.Properties["NewSchool"] = "0";
	result.Add(msg2);
	
	var msg1 = new BrokeredMessage("First Message");
	msg1.MessageId = "1";
	msg1.Properties["NewSchool"] = "1";
	result.Add(msg1);
	
	return result;
}

void ListenToAllMessages()
{
	var client = SubscriptionClient.CreateFromConnectionString(connectionString, SchoolUpdate, AllMessages);
	Console.WriteLine("Started listening to all messages");
	while (!tokenSource.IsCancellationRequested)
	{
		var msg = client.Receive(TimeSpan.FromSeconds(5));
		if (msg == null) continue;
		var message = msg.GetBody<string>();
		msg.Complete();
		if (!string.IsNullOrWhiteSpace(message))
		{
			Console.WriteLine($"All Message Subscription received message '{message}'");			
		}
	}
}

void ListenToFilteredMessages()
{
	var client = SubscriptionClient.CreateFromConnectionString(connectionString, SchoolUpdate, NewSchool);
	Console.WriteLine("Started listening to filtered messages");
	while (!tokenSource.IsCancellationRequested)
	{
		var msg = client.Receive(TimeSpan.FromSeconds(5));
		if (msg == null) continue;
		var message = msg.GetBody<string>();
		msg.Complete();
		if (!string.IsNullOrWhiteSpace(message))
		{
			Console.WriteLine($"Filtered Message Subscription received message '{message}' ");
		}
	}

}