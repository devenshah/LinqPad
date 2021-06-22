<Query Kind="Program">
  <Namespace>System.Text.Json</Namespace>
</Query>

void Main()
{
	//UK is +01:00

	var jsons = new[] {
		@"{""EventDate"":""2021-05-14T15:49:00+02:00""}",
		@"{""EventDate"":""2021-05-14T15:49:00Z""}",
		@"{""EventDate"":""2021-05-14T15:49:00""}"
	};
	foreach (var json in jsons)
	{
		var jsonBytes = Encoding.UTF8.GetBytes(json);
		JsonSerializer.Deserialize<MyEvent>(jsonBytes).EventDate.Dump();
	}
	
//	DateTime.UtcNow.Dump();
//
//	JsonSerializer.Serialize(new MyEvent {EventDate = DateTime.Now}).Dump();
}

class MyEvent { public DateTime EventDate { get; set; }}

void Main1()
{
	DateTime.Now.Dump("Current UK Time");
	DateTime.UtcNow.Dump("Current UTC Time");
	
	var jsons = new[] {
		@"{""EventDate"":""2021-05-14T15:49:00+02:00""}", //full time
		@"{""EventDate"":""2021-05-14T15:49:00.000Z""}", // full time
		@"{""EventDate"":""2021-05-14T15:49:00""}" //local time
	};
	foreach (var json in jsons)
	{
		var jsonBytes = Encoding.UTF8.GetBytes(json);
		JsonSerializer.Deserialize<MyEvent>(jsonBytes).EventDate.Dump();
	}
}

