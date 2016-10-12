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
	var connString = "Endpoint=sb://etech-etech-dev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=2a99ZavJbHvrYrRfPJ9VTsrX9pzNUqkzoRyQXnGGhHY=";
	var queueName = "milestoneresponsequeue";
	queueName = QueueClient.FormatDeadLetterPath(queueName);
	
	var _queueClient = QueueClient.CreateFromConnectionString(connString, queueName);
	
	var messages = _queueClient.ReceiveBatch(40, TimeSpan.FromSeconds(2));

	const string deadLetterReason = "DeadLetterReason";

	var i = 1;

	messages.ForEach(m =>
	{
		Console.WriteLine($"{i}: Message With Id {m.MessageId} Of Type {m.ContentType} was Queued On {m.EnqueuedTimeUtc} Failed Due To {m.Properties[deadLetterReason]}");

		if (m.EnqueuedTimeUtc.Day == 7)
		{
			var obj = m.GetBody<eTech.CentralIntegration.Api.Messages.Messages.Milestones.MilestonesResponseMessage>();
			m.Abandon();
		}
		else m.Complete();
		i++;
	});
}

public IList<ServiceBusMessageResponse<T>> GetMessages<T>(int count)
{
	var result = new List<ServiceBusMessageResponse<T>>();
	var messages = ReceiveMessages(count);
	foreach (var brokeredMessage in messages)
	{
		result.Add(new ServiceBusMessageResponse<T>(brokeredMessage));
	}
	return result;
}

} ///// end of EOF for namespace 

public class ServiceBusMessageResponse<T>
{
	private BrokeredMessage _brokeredMessage;

	public ServiceBusMessageResponse(BrokeredMessage brokeredMessage)
	{
		_brokeredMessage = brokeredMessage;
		TranslateMessage();
	}

	public T Content { get; private set; }

	public Exception Error { get; private set; }

	public bool HasError
	{
		get
		{
			return Error != null;
		}
	}

	public void Complete()
	{
		CheckMessageIsNull();
		_brokeredMessage.Complete();
		_brokeredMessage = null;
	}

	public void Abandon()
	{
		CheckMessageIsNull();
		_brokeredMessage.Abandon();
		_brokeredMessage = null;
	}

	public void DeadLetter(string deadLetterReason, string deadLetterErrorDescription)
	{
		CheckMessageIsNull();
		_brokeredMessage.DeadLetter(deadLetterReason, deadLetterErrorDescription);
		_brokeredMessage = null;
	}

	private void TranslateMessage()
	{
		try
		{
			var receivedType = _brokeredMessage.ContentType;
			var expectedType = typeof(T).ToString();
			if (expectedType.Equals(receivedType))
			{
				Content = _brokeredMessage.GetBody<T>();
				return;
			}
			Error = new Exception($"{expectedType} , {receivedType?.ToString()}");
		}
		catch (Exception ex)
		{
			Error = ex;
		}
		DeadLetter();
	}

	private void CheckMessageIsNull()
	{
		if (_brokeredMessage == null)
		{
			throw new Exception("There is no message to action");
		}
	}

	private void DeadLetter()
	{
		CheckMessageIsNull();
		_brokeredMessage.DeadLetter(Error.Message, Error.StackTrace);
		_brokeredMessage = null;
	}
}

namespace eTech.CentralIntegration.Api.Messages.Messages.Milestones
{
	public class MilestonesResponseMessage
	{
		public MilestonesResponseMessage()
		{
			Errors = new List<AgentResponseMessage>();
			Warnings = new List<AgentResponseMessage>();
			DebugMessages = new List<AgentResponseMessage>();
			Data = new Dictionary<string, string>();
		}

		public Guid MilestoneRequestId { get; set; }

		public Guid StatusId { get; set; }

		public int RetryCount { get; set; }

		public DateTime SubmittedDateTime { get; set; }

		public List<AgentResponseMessage> Errors { get; set; }

		public List<AgentResponseMessage> Warnings { get; set; }

		public List<AgentResponseMessage> DebugMessages { get; set; }

		public Dictionary<string, string> Data { get; set; }

		public string AgentId { get; set; }
	}

	public class AgentResponseMessage
	{
		public string AgentId { get; set; }

		public string Message { get; set; }
	}
}


class EOF {
