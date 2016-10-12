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
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var connString = "Endpoint=sb://etech-surveyhubesurv-onpremlive.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=toW0piZqoAWvhkl3LW8H22JPVAi2KbofHvoG5Z2OUXU=";
    var queueName = "milestoneresponsequeue";
	queueName = QueueClient.FormatDeadLetterPath(queueName);

	var _queueClient = QueueClient.CreateFromConnectionString(connString, queueName);

	var mesg = _queueClient.Peek();
	
	var response = mesg.GetBody<eTech.CentralIntegration.Api.Messages.Messages.Milestones.MilestonesResponseMessage>();
	
	ProcessResponse(response);
}

private  bool ProcessResponse(eTech.CentralIntegration.Api.Messages.Messages.Milestones.MilestonesResponseMessage milestonesResponseMessage)
{
	var milestoneResponse = new eTech.SurveyHub.Domain.Services.Milestones.Messages.MilestonesResponseMessage
	{
		AgentId = milestonesResponseMessage.AgentId,
		Data = milestonesResponseMessage.Data,
		DebugMessages = milestonesResponseMessage.DebugMessages,
		Errors = milestonesResponseMessage.Errors,
		MilestoneRequestId = milestonesResponseMessage.MilestoneRequestId,
		StatusId = milestonesResponseMessage.StatusId,
		Warnings = milestonesResponseMessage.Warnings,
		RetryCount = 0,
		SubmittedDateTime = milestonesResponseMessage.SubmittedDateTime
	};

	//await _milestoneService.UpdateAsync(milestoneResponse);

	return true;
}

}

public class AgentResponseMessage : ApiMessageBase
{
	public string AgentId { get; set; }

	public string Message { get; set; }
}

public abstract class ApiMessageBase
{
	protected ApiMessageBase()
	{
		Id = Guid.NewGuid();
	}

	public Guid Id { get; set; }
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

		public DateTime SubmittedDateTime { get; set; }

		public List<AgentResponseMessage> Errors { get; set; }

		public List<AgentResponseMessage> Warnings { get; set; }

		public List<AgentResponseMessage> DebugMessages { get; set; }

		public Dictionary<string, string> Data { get; set; }

		public string AgentId { get; set; }
	}

}

namespace eTech.SurveyHub.Domain.Services.Milestones.Messages
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

		public Guid CentralIntegrationHubInstanceId { get; set; }

		public Dictionary<string, string> Data { get; set; }

		public string AgentId { get; set; }
	}

}




class EOF {