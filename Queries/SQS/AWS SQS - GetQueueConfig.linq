<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>AutoMapper</NuGetReference>
  <NuGetReference>AWSSDK.SQS</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Amazon</Namespace>
  <Namespace>Amazon.SQS</Namespace>
  <Namespace>Amazon.SQS.Model</Namespace>
  <Namespace>AutoMapper</Namespace>
  <Namespace>AutoMapper.Configuration</Namespace>
  <Namespace>AutoMapper.Configuration.Conventions</Namespace>
  <Namespace>AutoMapper.Execution</Namespace>
  <Namespace>AutoMapper.Mappers</Namespace>
  <Namespace>AutoMapper.QueryableExtensions</Namespace>
  <Namespace>AutoMapper.QueryableExtensions.Impl</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

void Main()
{
	var result = new List<QueueAttributes>();
	var filter = "-dev";
	var client = new AmazonSQSClient("AKIAJIWNYZBWARL6IR3A","Qjqal4zjHjbW0wzkl/8A4SML0ySzPDirqHPxGLof", RegionEndpoint.EUWest1);

	var request = new ListQueuesRequest("catalog360");
	
	var response = client.ListQueues(request);

	var att = new List<string> {"VisibilityTimeout","MaximumMessageSize","MessageRetentionPeriod","RedrivePolicy"};

	var list = response.QueueUrls.Where(q => !q.Contains(filter) && !q.Contains("-deadletter") && !q.Contains("-failures")).ToList();

	list.ForEach(url =>
		{
			var attReq = new GetQueueAttributesRequest(url, att); //
			var attRes = client.GetQueueAttributes(attReq);
			var config = new QueueAttributes() {
				QueueUrl = url,
				QueueName = url.Replace("https://sqs.eu-west-1.amazonaws.com/460371557461/", string.Empty),
				VisibilityTimeout = attRes.VisibilityTimeout,
				MaximumMessageSize = attRes.MaximumMessageSize,
				MessageRetentionPeriod = attRes.MessageRetentionPeriod,
				IsDeadLetterEnabled = attRes.Attributes.ContainsKey("RedrivePolicy")
			};
			if (config.IsDeadLetterEnabled)
			{
				dynamic d = JObject.Parse(attRes.Attributes["RedrivePolicy"]);
				config.MaxReceiveCount = d.maxReceiveCount;
			}
			result.Add(config);
		});
	result.Dump();
	//JsonConvert.SerializeObject(result).Dump();
}


public class QueueAttributes
{
	public Guid Id {get; set;} = Guid.NewGuid();
	
	public string QueueUrl { get; set;}
	
	public string QueueName { get; set; }

	public int MaximumMessageSize { get; set; }

	public int VisibilityTimeout { get; set; }

	public int MessageRetentionPeriod { get; set; }

	public bool IsDeadLetterEnabled { get; set; }

	public int? MaxReceiveCount { get; set; }

}