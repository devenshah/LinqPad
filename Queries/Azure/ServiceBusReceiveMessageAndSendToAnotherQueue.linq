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

///sb://etech-onprem-dev.servicebus.windows.net/milestoneresponsequeue/$DeadLetterQueue
private readonly string _queueConnectionString = "Endpoint=sb://etech-onprem-dev.servicebus.windows.net;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8etT4mg3BVSBPGfoi72zSGSYBeaKR8v3P5jk2etKTH0=";

void Main()
{
	var queuePath = QueueClient.FormatDeadLetterPath("milestoneresponsequeue");	
	var message = ReceiveTestMessage(queuePath);
	if (message == null) 
		return;
	sendTestMessage(message.Clone(), "test");
	message.Complete();
}

BrokeredMessage ReceiveTestMessage(string queuePath)
{	
	var client = QueueClient.CreateFromConnectionString(_queueConnectionString, queuePath);	
	var message = client.Receive(TimeSpan.FromSeconds(2));
	if (message == null) return null;
	return message;
}

void sendTestMessage(BrokeredMessage message, string queuePath)
{
	try
	{	        
		var client = QueueClient.CreateFromConnectionString(_queueConnectionString, queuePath);
		client.Send(message);
	}
	catch (Exception ex)
	{
		message.Abandon();
		throw;
	}
}


