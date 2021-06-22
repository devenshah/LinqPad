<Query Kind="Program">
  <NuGetReference>Azure.Messaging.ServiceBus</NuGetReference>
  <Namespace>Azure.Messaging.ServiceBus.Administration</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//Delete all
private ServiceBusAdministrationClient client = new ServiceBusAdministrationClient(Environment.GetEnvironmentVariable("SS_SERVICEBUS_CONNECTION_STRING"));

//Delete all queues
async Task Main1()
{
	await foreach (var queue in client.GetQueuesAsync())
	{
		Console.WriteLine($"Deleting {queue.Name}");
		await client.DeleteQueueAsync(queue.Name);
	}
}

//Check ForwardTo fails is queue is missing
async Task Main2()
{
	await client.CreateQueueAsync("ForwardToQueue");
	// Cannot create below queue before above is created
	await client.CreateQueueAsync(new CreateQueueOptions("ForwardingQueue") {ForwardTo="ForwardToQueue"});
}

//Creates a topic
async Task Main3()
{
	var topic = await client.CreateTopicAsync("FirstTopic");
	var sub = await client.CreateSubscriptionAsync(new CreateSubscriptionOptions("FirstTopic", "mysub1"));
	var rule = await client.GetRuleAsync("FirstTopic", "mysub1", "$Default");
	rule.Value.Filter = new SqlRuleFilter("name='don'");
	await client.UpdateRuleAsync("FirstTopic", "mysub1", rule.Value);
	
	//await client.CreateRuleAsync("FirstTopic", "AllMessages",new CreateRuleOptions("$default", new SqlRuleFilter("1=1")));
}

//Delete all topics
async Task Main4()
{
	await foreach (var topic in client.GetTopicsAsync())
	{
		Console.WriteLine($"Deleting {topic.Name}");
		await client.DeleteTopicAsync(topic.Name);
	}
}
