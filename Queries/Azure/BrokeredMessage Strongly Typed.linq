<Query Kind="Program">
  <NuGetReference>AutoMapper</NuGetReference>
  <NuGetReference>WindowsAzure.ServiceBus</NuGetReference>
  <Namespace>Microsoft.Azure</Namespace>
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

void Main()
{
	var p = new Person { Id = 123, Name = "Deven"};
	p.ToString().Dump("Original Person");
	var message = PushMessage<Person>(p.Id.ToString(), p);

	var bodyType = message.Properties["PayloadType"] as Type;
	var methodInfo = typeof(BrokeredMessage).GetMethod("GetBody", new Type[] {});
	var genericMethod = methodInfo.MakeGenericMethod(bodyType);
	
	var p1 = genericMethod.Invoke(message, null);
	p1.ToString().Dump("Restored Person");
}

public BrokeredMessage PushMessage<T>(string messageId, T payload)
{
	var message = new BrokeredMessage(payload);
	message.MessageId = messageId;
	message.Properties.Add("PayloadType", typeof(T));
	return message;
}

public class Person
{
	public Guid UniqueId { get; } = Guid.NewGuid();
	public int Id { get; set; }
	public string Name { get; set; }
	public override string ToString()
	{
		return $"UId:{UniqueId}, Id:{Id}, Name:{Name}";
	}
}

