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

void Main()
{
	
}

public class MessageAdaptor<T> where T : new
{
	private readonly BrokeredMessage _brokeredMessage;
	
	public MessageAdaptor(BrokeredMessage brokeredMessage)
	{
		_brokeredMessage = brokeredMessage
	}
	
	public async Task MoveToDeadLetterAsync()
	{
		await _brokeredMessage.DeadLetterAsync();
	}

	public async Task AbondonAsync()
	{
		await _brokeredMessage.AbandonAsync();
	}

	public T GetMessageBody()
	{
		var body = _brokeredMessage.GetBody<string>();
		return JsonConvert.DeserializeObject<T>(body);
	}
}