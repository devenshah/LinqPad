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

void Main()
{
	var container = ConfigureUnity();
	
	var b = container.Resolve<IFoo>();
	
	var p = new Person { Id = 123, Name = "Deven" };
	p.ToString().Dump("Original Person");
	var message = PushMessage<Person>(p.Id.ToString(), p);

	var a = new Address { Id = 456, Line1 = "Fore Business Park"};
	a.ToString().Dump("Original Address");
	var AMessage = PushMessage<Address>(a.Id.ToString(), a);

	HandleMessage(message, container);
	HandleMessage(AMessage, container);
}

public void HandleMessage(BrokeredMessage message, UnityContainer container)
{
	var bodyType = message.Properties["PayloadType"] as Type;
	var methodInfo = typeof(BrokeredMessage).GetMethod("GetBody", new Type[] { });
	var genericMethod = methodInfo.MakeGenericMethod(bodyType);
	var p1 = genericMethod.Invoke(message, null);

	var handlerType = typeof(IMessageHandler<>);
	Type[] typeArgs = { p1.GetType() };
	Type constructed = handlerType.MakeGenericType(typeArgs);
	var handler = container.Resolve(constructed, null);

	var methodInfo1 = constructed.GetMethod("Handle");
	methodInfo1.Invoke(handler, new[] { p1});
}

public UnityContainer ConfigureUnity()
{
	// http://www.danderson00.com/2010/09/automatically-register-implementors-of.html
	// https://msdn.microsoft.com/en-us/library/dn507479(v=pandp.30).aspx
	// http://stackoverflow.com/questions/32834760/register-generic-types-with-concrete-types-in-unity-by-convention

	var container = new UnityContainer();

	//Register generic interface for non generic implementation
	container.RegisterTypes(
		AllClasses
			.FromLoadedAssemblies()
			.Where(t =>
			   t.GetInterfaces().Any(i =>
				   i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMessageHandler<>)))
		, WithMappings.FromAllInterfaces);
	
	//Register all by convention Foo for IFoo
	container.RegisterTypes(AllClasses.FromLoadedAssemblies(), WithMappings.FromMatchingInterface);

//	var ph = container.Resolve<IMessageHandler<Person>>();
//	ph.GetType().ToString().Dump();
//	var ad = container.Resolve<IMessageHandler<Address>>();
//	ad.GetType().ToString().Dump();
	return container;
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

public class Address
{
	public Guid UniqueId { get; } = Guid.NewGuid();
	public int Id { get; set; }
	public string Line1 { get; set; }
	public override string ToString()
	{
		return $"UId:{UniqueId}, Id:{Id}, Address:{Line1}";
	}
}

public interface IMessageHandler<T>
{
	void Handle(T message);
}

public class PersonMessageHandler : IMessageHandler<Person>
{
	public void Handle(Person message)
	{
		message.ToString().Dump("From Person Handler");
	}
}

public class AddressMessageHandler : IMessageHandler<Address>
{
	public void Handle(Address message)
	{
		message.ToString().Dump("From Address Handler");
	}
}

public interface IFoo { }

public class Foo : IFoo { }


