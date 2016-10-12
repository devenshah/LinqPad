<Query Kind="Program">
  <NuGetReference>AutoMapper</NuGetReference>
  <NuGetReference>Unity</NuGetReference>
  <NuGetReference>WindowsAzure.ServiceBus</NuGetReference>
  <Namespace>Microsoft.Azure</Namespace>
  <Namespace>Microsoft.Practices.ObjectBuilder2</Namespace>
  <Namespace>Microsoft.Practices.ServiceLocation</Namespace>
  <Namespace>Microsoft.Practices.Unity</Namespace>
  <Namespace>Microsoft.Practices.Unity.Configuration</Namespace>
  <Namespace>Microsoft.Practices.Unity.Configuration.ConfigurationHelpers</Namespace>
  <Namespace>Microsoft.Practices.Unity.ObjectBuilder</Namespace>
  <Namespace>Microsoft.Practices.Unity.StaticFactory</Namespace>
  <Namespace>Microsoft.Practices.Unity.Utility</Namespace>
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
</Query>

private readonly string _queueConnectionString = "Endpoint=sb://surveyhubtest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=yFQ0eEowqMoWW4qx5xx+AHpFRoHnKFy4SJx73zssLJM=";
private readonly string _queueName = "milestoneresponsequeue";
private QueueClient _queueClient;


void Main()
{
	//	CreateQueue("milestonerequestsqueue");
	//	CreateQueue("milestoneresponsequeue");

	//var queueName = _queueName;
	var queueName = QueueClient.FormatDeadLetterPath(_queueName);
	_queueClient = QueueClient.CreateFromConnectionString(_queueConnectionString, queueName);	
	
	//sendTestMessage(5);

	//receiveAndDeadLetterBatch(5);
	
	receiveAndCompleteBatch(15);
}

private void CreateQueue(string queueName)
{
	var qd = new QueueDescription(queueName);
	qd.EnableBatchedOperations = true;
	qd.EnableExpress = true;
	qd.LockDuration = TimeSpan.FromMinutes(5);
	var namespaceManager = NamespaceManager.CreateFromConnectionString(_queueConnectionString);
	if (namespaceManager.QueueExists(queueName)) return;	
	namespaceManager.CreateQueue(qd);
}

void sendTestMessage(int count)
{
	for (var i = 0; i < count; i++)
	{
		_queueClient.Send(new BrokeredMessage("Hello World!") { MessageId = DateTime.Now.Ticks.ToString()});
	}
}

void receiveAndCompleteBatch(int count)
{
	var messages = _queueClient.ReceiveBatch(count, TimeSpan.FromSeconds(2));
	messages.ForEach(m =>
	{
		Console.WriteLine(m.MessageId);
		m.Complete();
		m.Dispose();
	});
}

void receiveAndDeadLetterBatch(int count)
{
	var messages = _queueClient.ReceiveBatch(count, TimeSpan.FromSeconds(2));
	messages.ForEach(m =>
	{
		Console.WriteLine(m.MessageId);
		m.DeadLetter("SomeError", "Due to some error");
		m.Dispose();
	});

}