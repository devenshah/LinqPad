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

const string connectionString = 
//"Endpoint=sb://simscloudintegration-local.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=nxLUUJaEIBM4A9WoSKSDdQbAD1g1MV0KU5Q0hbmD5dI=";
"Endpoint=sb://simslabs-servicebus-backbone-local.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Y31in3tSbHBBBtixD7CXd4YkOG5PNkn5aVRyXnow5jQ=";
//"Endpoint=sb://simslabs-servicebus-backbone-dev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=aNwEglxTnVbSxzdLqECG1bdbxhqeYoq4hjZcYhj0BKs=";
//"Endpoint=sb://simscloudintegration-test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3d+Cxo7VbfgYuky3ACYwxjxMl/SMogSo8ajFtm1FZ/I=";

static CancellationTokenSource tokenSource = new CancellationTokenSource();

void Main()
{
	//var topic = "temp-topic";
	//var subscription = "temp";
	//MoveMessageToDeadLetter(topic, subscription);
	//SendMessage(new BrokeredMessage("faulty message"));
	//SendMessage(GetSchoolUpdateMessage(), SchoolUpdate);
	SendSchoolSyncMessage();
}

BrokeredMessage GetSchoolSyncMessage()
{
	var msg = new BrokeredMessage(
		JsonConvert.SerializeObject(
			new SchoolUpdateMessage()
			{
				//SchoolGuid = Guid.NewGuid(),
				SchoolGuid = Guid.Parse("d69cf4c2-6341-4c58-af34-416a24c2fbaa"),
				SchoolName = "Gurukul School",
				UsesSimsPrimary = true,
				LeaNumber = "223",
				SchoolNumber = "4321",
				Postcode = "Mumbai"
			}));
	//msg.Log();
	return msg;
}


BrokeredMessage GetSchoolUpdateMessage()
{
	var msg = new BrokeredMessage(
		JsonConvert.SerializeObject(
			new SchoolUpdateMessage() {
				//SchoolGuid = Guid.NewGuid(),
				SchoolGuid = Guid.Parse("d69cf4c2-6341-4c58-af34-416a24c2fbaa"),
				SchoolName = "Gurukul School",
				UsesSimsPrimary = true,
				LeaNumber = "223",
				SchoolNumber = "4321",
				Postcode = "Mumbai"
			}));
			//msg.Log();
	return msg;
}

void SendMessage(BrokeredMessage message)
{
	var client = TopicClient.CreateFromConnectionString(connectionString, SchoolUpdate);
	client.Send(message);
}

void SendSchoolSyncMessage()
{
	var _connectionString="Endpoint=sb://simscloudintegration-local.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=V7vhSIrLznscLq0zBt5SNDbKAfgHt/bHupj8QAXeUIc=";
	var _queue = "syncschool-agorapastoral";
	var client = QueueClient.CreateFromConnectionString(_connectionString, _queue);
	var message = new BrokeredMessage(JsonConvert.SerializeObject(Guid.NewGuid()));
	client.Send(message);
}


void MoveMessageToDeadLetter(string topic, string subscription)
{
	var client = SubscriptionClient.CreateFromConnectionString(connectionString, topic, subscription);
	Console.WriteLine("Started listening to all messages");
	var msg = client.Receive(TimeSpan.FromSeconds(5));
	if (msg == null) return;
	msg.DeadLetter();
}


void SendMessage(BrokeredMessage message, string topic)
{
	var client = TopicClient.CreateFromConnectionString(connectionString, topic);
	client.Send(message);
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
	msg3.Properties["NewSchool"] = "1";
	result.Add(msg3);

	var msg2 = new BrokeredMessage("Second Message");
	msg2.Properties["NewSchool"] = "0";
	result.Add(msg2);
	
	var msg1 = new BrokeredMessage("First Message");
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