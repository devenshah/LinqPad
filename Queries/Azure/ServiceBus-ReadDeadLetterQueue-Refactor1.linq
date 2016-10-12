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
	//var connString = "Endpoint=sb://etech-etech-dev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=2a99ZavJbHvrYrRfPJ9VTsrX9pzNUqkzoRyQXnGGhHY=";
	//var connString = "Endpoint=sb://surveyhubtest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=yFQ0eEowqMoWW4qx5xx+AHpFRoHnKFy4SJx73zssLJM=";
	var queueName = "milestoneresponsequeue";
	queueName = QueueClient.FormatDeadLetterPath(queueName);
	
	var _queueClient = QueueClient.CreateFromConnectionString(connString, queueName);
	
	const string deadLetterReason = "DeadLetterReason";
	
	var messages = GetMessages<eTech.CentralIntegration.Api.Messages.Messages.Milestones.MilestonesResponseMessage>(10, _queueClient);

	var i = 1;

	messages.ForEach(m =>
	{
		var obj = m.Content;

		Console.WriteLine($"{i}: Message With Id {obj.MilestoneRequestId} Of Type {m.BrokeredMessage.ContentType} was Queued On {m.BrokeredMessage.EnqueuedTimeUtc} Failed Due To {m.BrokeredMessage.Properties[deadLetterReason]}");

		if (m.HasError)
		{
			Console.WriteLine(m.Error);
		}

		m.Abandon();
		
		i++;
	});
}

void DeleteAllDeadLetter(QueueClient qc)
{
	var message = qc.Receive(TimeSpan.FromSeconds(1));
	while (message != null)
	{
		message.Complete();
		message= null;
		message = qc.Receive(TimeSpan.FromSeconds(1));
	}
}

public IList<ServiceBusMessageResponse<T>> GetMessages<T>(int count, QueueClient queueClient)
{
	var result = new List<ServiceBusMessageResponse<T>>();
	var messages = queueClient.ReceiveBatch(40, TimeSpan.FromSeconds(2));
	foreach (var brokeredMessage in messages)
	{
		if (string.IsNullOrEmpty(brokeredMessage.ContentType))
		{
			Console.WriteLine($"Deleting Message With Id {brokeredMessage.MessageId} Queued On {brokeredMessage.EnqueuedTimeUtc}");
			brokeredMessage.Complete();
		}
		else
		{
			result.Add(new ServiceBusMessageResponse<T>(brokeredMessage));
		}
	}
	return result;
}

} ///// end of EOF for namespace 

public class ServiceBusMessageResponse<T>
{
	public BrokeredMessage BrokeredMessage { get; private set; }

	public ServiceBusMessageResponse(BrokeredMessage brokeredMessage)
	{
		BrokeredMessage = brokeredMessage;
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
		BrokeredMessage.Complete();
		BrokeredMessage = null;
	}

	public void Abandon()
	{
		CheckMessageIsNull();
		BrokeredMessage.Abandon();
		BrokeredMessage = null;
	}

	public void DeadLetter(string deadLetterReason, string deadLetterErrorDescription)
	{
		CheckMessageIsNull();
		BrokeredMessage.DeadLetter(deadLetterReason, deadLetterErrorDescription);
		BrokeredMessage = null;
	}

	private void TranslateMessage()
	{
		try
		{
			var receivedType = BrokeredMessage.ContentType;
			var expectedType = typeof(T).ToString();
			if (expectedType.Equals(receivedType))
			{
				Content = BrokeredMessage.GetBody<T>();
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
		if (BrokeredMessage == null)
		{
			throw new Exception("There is no message to action");
		}
	}

	private void DeadLetter()
	{
		CheckMessageIsNull();
		BrokeredMessage.DeadLetter(Error.Message, Error.StackTrace);
		BrokeredMessage = null;
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
