<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>AWSSDK.SQS</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Amazon</Namespace>
  <Namespace>Amazon.SQS</Namespace>
  <Namespace>Amazon.SQS.Model</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

void Main()
{
	var result = new List<string>();
	
	var envs = new string[] {"testing__", "qa__", "preview__", "dev__"};
	
	var list = GetListOfQueues();
	
	var defaultAtts = new Dictionary<string, string>();
	defaultAtts.Add("VisibilityTimeout", "600");
	defaultAtts.Add("MaximumMessageSize", "262144");
	defaultAtts.Add("MessageRetentionPeriod", "1209600");

	foreach (var env in envs)
	{
		list.ForEach(url =>
			{
				var atts = GetAttributes(url);
								
				var queueName = url.Replace("https://sqs.eu-west-1.amazonaws.com/460371557461/", string.Empty);
				queueName = env + queueName;

				if (atts.ContainsKey("RedrivePolicy"))
				{
					var dlqName = queueName + "__deadletter";
					var dlUrl = CreateQueue(dlqName, defaultAtts);
					result.Add(dlUrl);
					
					var redrivePolicy = new RedrivePolicy();
					redrivePolicy.deadLetterTargetArn = GetArn(dlUrl);
					redrivePolicy.maxReceiveCount = 10;
					atts["RedrivePolicy"] = JsonConvert.SerializeObject(redrivePolicy);
	            }
				
				var qUrl = CreateQueue(queueName, atts);
				result.Add(qUrl);
			});
	}
	result.Dump();
}

private AmazonSQSClient client = new AmazonSQSClient("AKIAJIWNYZBWARL6IR3A","Qjqal4zjHjbW0wzkl/8A4SML0ySzPDirqHPxGLof", RegionEndpoint.EUWest1);



public class RedrivePolicy
{
	public string deadLetterTargetArn { get; set; }

	public int maxReceiveCount { get; set; }
}


string CreateQueue(string queueName, Dictionary<string, string> atts)
{
	var list = new List<string>();
	var createQReq = new CreateQueueRequest();
	createQReq.QueueName = queueName;
	createQReq.Attributes = atts;
	var createQRes = client.CreateQueue(createQReq);
	return createQRes.QueueUrl;
}

List<string> GetListOfQueues()
{
	var request = new ListQueuesRequest("catalog360");
	//var request = new ListQueuesRequest("catalog360-requisition");

	var response = client.ListQueues(request);

	var list = 
		response.QueueUrls
			.Where(q => !q.Contains("-dev") && !q.Contains("-deadletter") && !q.Contains("-failures"))
			.ToList();

	return list;
}

Dictionary<string, string> GetAttributes(string url)
{
	var att = new List<string> { "VisibilityTimeout", "MaximumMessageSize", "MessageRetentionPeriod", "RedrivePolicy"};
	var attReq = new GetQueueAttributesRequest(url, att); //
	var attRes = client.GetQueueAttributes(attReq);
	return attRes.Attributes;
}

string GetArn(string url)
{
	var attReq = new GetQueueAttributesRequest(url, new List<string> { "QueueArn"}); //
	var attRes = client.GetQueueAttributes(attReq);
	return attRes.QueueARN;
}